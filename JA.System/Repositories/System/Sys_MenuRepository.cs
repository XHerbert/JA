using JA.System.IRepositories;
using JA.Core.BaseProvider;
using JA.Core.Extensions.AutofacManager;
using JA.Core.EFDbContext;
using JA.Entity.DomainModels;

namespace JA.System.Repositories
{
    public partial class Sys_MenuRepository : RepositoryBase<Sys_Menu>, ISys_MenuRepository
    {
        public Sys_MenuRepository(JAContext dbContext)
        : base(dbContext)
        {

        }
        public static ISys_MenuRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_MenuRepository>(); }
        }
    }
}

