/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹TenantHouseRelationController编写
 */
using Microsoft.AspNetCore.Mvc;
using JA.Core.Controllers.Basic;
using JA.Entity.AttributeManager;
using JA.Business.IServices;
namespace JA.Business.Controllers
{
    [Route("api/TenantHouseRelation")]
    [PermissionTable(Name = "TenantHouseRelation")]
    public partial class TenantHouseRelationController : ApiBaseController<ITenantHouseRelationService>
    {
        public TenantHouseRelationController(ITenantHouseRelationService service)
        : base(service)
        {
        }
    }
}

