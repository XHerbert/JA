/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *所有关于Vtenanthouserelation类的业务代码应在此处编写
 *可使用repository.调用常用方法，获取EF/Dapper等信息
 *如果需要事务请使用repository.DbContextBeginTransaction
 *也可使用DBServerProvider.手动获取数据库相关信息
 *用户信息、权限、角色等使用UserContext.Current操作
 *VtenanthouserelationService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System.Collections.Generic;
using JA.Core.ManageUser;
using JA.Business.Utils;
using System;
using JA.Business.Repositories;

namespace JA.Business.Services
{
    public partial class VtenanthouserelationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVtenanthouserelationRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public VtenanthouserelationService(
            IVtenanthouserelationRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            WebResponseContent webResponseContent = WebResponseContent.Instance;
            AddOnExecuting = (Vtenanthouserelation relation, object list) =>
            {
                return null;
            };
            int role = UserContext.Current.RoleId;
            SaveModel model = new SaveModel();
            int belongUnit = RoleHelper.GetBelongUnitByUserRole(role);
            //增加记录
            saveDataModel.MainData.Add("EnableFlag", 1);
            saveDataModel.MainData.Add("BelongUnit", belongUnit);
            TenantHouseRelationService.Instance.Add(saveDataModel);

         

            //更新房屋状态

            House h = new House
            {
                Id = Convert.ToInt32(saveDataModel.MainData["HouseId"]),
                RentStatus = 1
            };


            Expression<Func<House, object>> expTree = x => new { x.RentStatus };
            HouseRepository.Instance.Update(h, expTree, true);
            return webResponseContent.OK("配置成功");
        }

        public override PageGridData<Vtenanthouserelation> GetPageData(PageDataOptions options)
        {
            QueryRelativeExpression = (IQueryable<Vtenanthouserelation> query) =>
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
