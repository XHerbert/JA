/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *所有关于Tenant类的业务代码应在此处编写
 *可使用repository.调用常用方法，获取EF/Dapper等信息
 *如果需要事务请使用repository.DbContextBeginTransaction
 *也可使用DBServerProvider.手动获取数据库相关信息
 *用户信息、权限、角色等使用UserContext.Current操作
 *TenantService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System;
using JA.Core.ManageUser;
using JA.Business.Utils;

namespace JA.Business.Services
{
    public partial class TenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITenantRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public TenantService(
            ITenantRepository dbRepository,
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

            AddOnExecuting = (Tenant tenant, object list) =>
            {
                string prefixCode = "ZK";
                string code = $"{prefixCode}{DateTime.Now.ToString("yyyyMMddHHMMssfff")}";
                tenant.TenantCode = code;
                return webResponseContent.OK();
            };
            return base.Add(saveDataModel);
        }

        public override PageGridData<Tenant> GetPageData(PageDataOptions options)
        {
            QueryRelativeExpression = (IQueryable<Tenant> query) =>
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
