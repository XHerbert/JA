/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *所有关于House类的业务代码应在此处编写
 *可使用repository.调用常用方法，获取EF/Dapper等信息
 *如果需要事务请使用repository.DbContextBeginTransaction
 *也可使用DBServerProvider.手动获取数据库相关信息
 *用户信息、权限、角色等使用UserContext.Current操作
 *HouseService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using JA.Entity.DomainModels;
using JA.Core.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using JA.Business.IRepositories;
using System;
using System.Linq;
using JA.Core.ManageUser;
using JA.Business.Utils;

namespace JA.Business.Services
{
    public partial class HouseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHouseRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public HouseService(
            IHouseRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            WebResponseContent responseContent = WebResponseContent.Instance;

            AddOnExecuting = (House house, object list) =>
            {
                //根据当前所属单位生成中间两位编码
                string prefixCode = "FW";
                string middleCode = $"0{saveDataModel.MainData["BelongUnit"]}";
                string code = $"{prefixCode}{middleCode}{DateTime.Now.ToString("yyyyMMddHHMMssfff")}";
                house.HouseCode = code;
                return responseContent.OK();
            };
            return base.Add(saveDataModel);
        }

        /// <summary>
        /// 根据用户角色筛选数据
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public override PageGridData<House> GetPageData(PageDataOptions options)
        {
            QueryRelativeExpression = (IQueryable<House> query) =>
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
    }
}
