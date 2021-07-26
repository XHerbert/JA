using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JA.Core.Controllers.Basic;
using JA.Core.Enums;
using JA.Core.Filters;
using JA.Entity.DomainModels;
using JA.System.IServices;

namespace JA.System.Controllers
{
    [Route("api/menu")]
    [ApiController, JWTAuthorize()]
    public partial class Sys_MenuController : ApiBaseController<ISys_MenuService>
    {
        private ISys_MenuService _service { get; set; }
        public Sys_MenuController(ISys_MenuService service) :
            base("System", "System", "Sys_Menu", service)
        {
            _service = service;
        } 
    }
}
