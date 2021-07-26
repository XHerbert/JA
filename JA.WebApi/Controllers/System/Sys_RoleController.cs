using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using JA.Core.Controllers.Basic;
using JA.Core.Enums;
using JA.Core.Filters;
using JA.Entity.AttributeManager;
using JA.Entity.DomainModels;
using JA.System.IServices;

namespace JA.System.Controllers
{
    [Route("api/Sys_Role")]
    [PermissionTable(Name = "Sys_Role")]
    public partial class Sys_RoleController : ApiBaseController<ISys_RoleService>
    {
        public Sys_RoleController(ISys_RoleService service)
        : base("System", "System", "Sys_Role", service)
        {

        }
    }
}


