using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JA.Core.Controllers.Basic;
using JA.Core.Extensions;
using JA.Core.Filters;
using JA.System.IServices;

namespace JA.System.Controllers
{
    [Route("api/Sys_Dictionary")]
    public partial class Sys_DictionaryController : ApiBaseController<ISys_DictionaryService>
    {
        public Sys_DictionaryController(ISys_DictionaryService service)
        : base("System", "System", "Sys_Dictionary", service)
        {
        }
    }
}
