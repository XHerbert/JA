using JA.Builder.IRepositories;
using JA.Core.BaseProvider;
using JA.Core.EFDbContext;
using JA.Core.Extensions.AutofacManager;
using JA.Entity.DomainModels;

namespace JA.Builder.Repositories
{
    public partial class Sys_TableInfoRepository : RepositoryBase<Sys_TableInfo>, ISys_TableInfoRepository
    {
        public Sys_TableInfoRepository(JAContext dbContext)
        : base(dbContext)
        {

        }
        public static ISys_TableInfoRepository GetService
        {
            get { return AutofacContainerModule.GetService<ISys_TableInfoRepository>(); }
        }
    }
}

