/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹VtenanthouserelationController编写
 */
using Microsoft.AspNetCore.Mvc;
using JA.Core.Controllers.Basic;
using JA.Entity.AttributeManager;
using JA.Business.IServices;
namespace JA.Business.Controllers
{
    [Route("api/Vtenanthouserelation")]
    [PermissionTable(Name = "Vtenanthouserelation")]
    public partial class VtenanthouserelationController : ApiBaseController<IVtenanthouserelationService>
    {
        public VtenanthouserelationController(IVtenanthouserelationService service)
        : base(service)
        {
        }
    }
}

