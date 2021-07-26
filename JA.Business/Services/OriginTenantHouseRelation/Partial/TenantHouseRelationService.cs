/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *所有关于TenantHouseRelation类的业务代码应在此处编写
 *可使用repository.调用常用方法，获取EF/Dapper等信息
 *如果需要事务请使用repository.DbContextBeginTransaction
 *也可使用DBServerProvider.手动获取数据库相关信息
 *用户信息、权限、角色等使用UserContext.Current操作
 *TenantHouseRelationService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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

namespace JA.Business.Services
{
    public partial class TenantHouseRelationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITenantHouseRelationRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public TenantHouseRelationService(
            ITenantHouseRelationRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
    }
}
