using JA.System.IRepositories;
using JA.Core.BaseProvider;
using JA.Core.Extensions.AutofacManager;
using JA.Core.EFDbContext;
using JA.Entity.DomainModels;

namespace JA.System.Repositories
{
    public partial class Sys_MenuRepository
    {
        public override JAContext DbContext => base.DbContext;
    }
}

