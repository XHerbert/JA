using JA.System.IRepositories;
using JA.Core.BaseProvider;
using JA.Core.Extensions.AutofacManager;
using JA.Core.EFDbContext;
using JA.Entity.DomainModels;

namespace JA.System.Repositories
{
    public partial class Sys_LogRepository : RepositoryBase<Sys_Log>, ISys_LogRepository
    {
        public Sys_LogRepository(JAContext dbContext)
        : base(dbContext)
        {

        }
        public static ISys_LogRepository GetService
        {
            get { return AutofacContainerModule.GetService<ISys_LogRepository>(); }
        }
    }
}

