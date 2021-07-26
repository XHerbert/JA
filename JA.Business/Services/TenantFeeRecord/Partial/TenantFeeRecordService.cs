/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *所有关于TenantFeeRecord类的业务代码应在此处编写
 *可使用repository.调用常用方法，获取EF/Dapper等信息
 *如果需要事务请使用repository.DbContextBeginTransaction
 *也可使用DBServerProvider.手动获取数据库相关信息
 *用户信息、权限、角色等使用UserContext.Current操作
 *TenantFeeRecordService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using JA.Core.BaseProvider;
using JA.Core.Extensions.AutofacManager;
using JA.Entity.DomainModels;
using System.Linq;
using JA.Core.Utilities;
using System.Linq.Expressions;
using JA.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using JA.Business.IRepositories;
using JA.Core.ManageUser;
using JA.Business.Utils;
using System.Collections.Generic;
using System;
using JA.Core.DBManager;
using JA.Business.Repositories;

namespace JA.Business.Services
{
    public partial class TenantFeeRecordService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITenantFeeRecordRepository _repository;
        private readonly IVtenanthouserelationRepository _relationRepository;

        [ActivatorUtilitiesConstructor]
        public TenantFeeRecordService(
            ITenantFeeRecordRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IVtenanthouserelationRepository tenantHouseRelationRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _relationRepository = tenantHouseRelationRepository;
        }


        public override PageGridData<TenantFeeRecord> GetPageData(PageDataOptions options)
        {
            QueryRelativeExpression = (IQueryable<TenantFeeRecord> query) =>
            {
                int role = UserContext.Current.RoleId;
                bool isAdmin = UserContext.Current.IsSuperAdmin;
                bool isSystemAdmin = UserContext.Current.IsSystemAdmin;
                if (!isAdmin && !isSystemAdmin)
                {
                    int belongUnit = RoleHelper.GetBelongUnitByUserRole(role);
                    query = query.Where(x => x.BelongUnit == belongUnit);
                }
                return query;
            };
            return base.GetPageData(options);
        }

        public int GeneratePeriodRentRecord()
        {

            //获取当前登录人信息，生成本月应收记录，供银行拉取数据并代扣租金

            var user = UserContext.Current.UserInfo;

            var belongUnit = RoleHelper.GetBelongUnitByUserRole(user.Role_Id);

            //查询是否已经生成本月应收记录，如果已经生成则不允许再次生成
            var period = DateTimeHelper.GetCurrentPeriod(System.DateTime.Now);
            TenantFeeRecord tenantFeeRecord = _repository.FindFirstAsync(item => item.Period == period && item.BelongUnit == belongUnit).Result;

            if (tenantFeeRecord != null)
            {
                return 0;
            }

            //TODO:需要明确管理员是否可以生成应收记录

            var unitTenantRelation = _relationRepository.FindAsIQueryable(item => item.BelongUnit == belongUnit).ToList();

            var periodRentList = new List<TenantFee>();

            //拉取所有租户租房信息，生成本月应收记录

            unitTenantRelation.ForEach(item =>
            {
                TenantFee record = new TenantFee();
                record.Period = period;
                record.ActualPaidRent = 0;
                record.Code = GenerateCode();
                record.Crash = 0;
                record.FeeFromBank = 0;
                record.HouseId = item.HouseId;
                record.NoFeeToBank = 0;
                record.OffsetPreReceivable = 0;
                record.PayStatus = 1;
                record.PreReceivable = 0;
                record.Receivable = item.RentFee;
                record.TenantId = item.TenantId;
                record.UnPaidRent = 0;
                record.CreateDate = DateTime.Now;
                record.Creator = user.UserName;
                record.CreatorID = user.User_Id;
                record.ModifyDate = DateTime.Now;
                periodRentList.Add(record);
            });

            //批量插入时报错，需要设置SET GLOBAL local_infile=1
            var result = DBServerProvider.SqlDapper.BulkInsert<TenantFee>(periodRentList);
            return result;
        }

        private string GenerateCode()
        {
            string prefixCode = "RF";
            string uuid = Guid.NewGuid().ToString().Split("-")[0];
            return $"{prefixCode}{DateTime.Now.ToString("yyyyMMdd")}{uuid}";

        }

        private string GetHouseType(int? houseType)
        {
            string houseTypeName = string.Empty;
            switch (houseType)
            {
                case 1:
                    houseTypeName = "直管公房";
                    break;
                case 2:
                    houseTypeName = "廉租房";
                    break;
                case 3:
                    houseTypeName = "公租房";
                    break;
                case 4:
                    houseTypeName = "过渡房";
                    break;
                default:
                    break;
            }
            return houseTypeName;
        }

        private string GetBelongUnit(int? unit)
        {
            string unitName = string.Empty;
            switch (unit)
            {
                case 1:
                    unitName = "一所";
                    break;
                case 2:
                    unitName = "二所";
                    break;
                case 3:
                    unitName = "三所";
                    break;
                case 4:
                    unitName = "企业所";
                    break;
                default:
                    unitName = "所有";
                    break;
            }
            return unitName;
        }

        /// <summary>
        /// 月租金报表
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public List<object> GetMonthRentReport(string period = null)
        {

            int role = UserContext.Current.UserInfo.Role_Id;
            string currentPeriod = period == null ? DateTime.Now.ToString("yyyyMM") : period;

            var user = UserContext.Current.UserInfo;

            var belongUnit = RoleHelper.GetBelongUnitByUserRole(user.Role_Id);

            IEnumerable<IGrouping<int?, TenantFeeRecord>> groups = (_repository.FindAsIQueryable(query => query.Period == currentPeriod && query.BelongUnit == belongUnit).ToList())
                .GroupBy(selector => selector.HouseType);


            List<object> report = new List<object>();

            foreach (var item in groups)
            {
                int? key = item.Key;
                //本月应收数
                decimal receivable = 0;
                //预收租金
                decimal preReceivable = 0;
                //收本年欠租
                decimal unPaidRent = 0;
                //补收租金
                decimal supplementRent = 0;
                //收历欠
                decimal ownFee = 0;
                //合计
                decimal receieveTotal = 0;

                //==============================
                //本月欠收
                decimal monthOwnFee = 0;
                //冲减预收租金
                decimal offsetPreReceivable = 0;

                //本月空租，需要单独考虑
                decimal emptyHouseFee = 0;

                //合计
                decimal payTotal = 0;

                //实收合计
                decimal? realReceieve = 0;


                foreach (var record in item)
                {
                    receivable += record.Receivable;
                    preReceivable += record.PreReceivable;
                    unPaidRent += record.UnPaidRent;

                    offsetPreReceivable += record.OffsetPreReceivable;
                }
                receieveTotal = receivable + preReceivable + unPaidRent;
                payTotal = offsetPreReceivable + emptyHouseFee;

                //实收金额计算方式？
                //根据所属单位筛选，表最好冗余【belongUnit】字段，在分配时直接写入
                
                var r = TenantHouseRelationRepository.Instance.Find(r => r.BelongUnit == belongUnit);
                r.ForEach(fee =>
                {
                    //分配房屋时有一个租金，银行缴费有一个租金，实际收缴二者应该是一致的
                    realReceieve += fee.ActualRentFee == null ? 0 : fee.ActualRentFee;
                });

                report.Add(new
                {
                    period = currentPeriod,
                    labelTitle = GetBelongUnit(belongUnit),
                    houseTypeName = GetHouseType(key),
                    receivable = receivable,
                    preReceivable = preReceivable,
                    unPaidRent = unPaidRent,

                    supplementRent = supplementRent,
                    ownFee = ownFee,
                    receieveTotal = receieveTotal,
                    monthOwnFee = monthOwnFee,
                    offsetPreReceivable = offsetPreReceivable,
                    emptyHouseFee = emptyHouseFee,
                    payTotal = payTotal,
                    realReceieve = realReceieve
                });
            }

            return report;
        }

        /// <summary>
        /// 月租金明细表
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public List<object> GetMonthRentDetailReport(string period = null)
        {
            return null;
        }
    }
}
