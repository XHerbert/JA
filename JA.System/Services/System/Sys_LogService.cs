using JA.System.IRepositories;
using JA.System.IServices;
using JA.Core.BaseProvider;
using JA.Core.Extensions.AutofacManager;
using JA.Entity.DomainModels;

namespace JA.System.Services
{
    public partial class Sys_LogService : ServiceBase<Sys_Log, ISys_LogRepository>, ISys_LogService, IDependency
    {
        public Sys_LogService(ISys_LogRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISys_LogService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_LogService>(); }
        }
    }
}

