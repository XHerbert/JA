/*
 *Author：jxx
 *Contact：283591387@qq.com
 *Date：2018-07-01
 * 此代码由框架生成，请勿随意更改
 */
using JA.System.IRepositories;
using JA.Core.BaseProvider;
using JA.Core.EFDbContext;
using JA.Core.Extensions.AutofacManager;
using JA.Entity.DomainModels;

namespace JA.System.Repositories
{
    public partial class Sys_DictionaryListRepository : RepositoryBase<Sys_DictionaryList>, ISys_DictionaryListRepository
    {
        public Sys_DictionaryListRepository(JAContext dbContext)
        : base(dbContext)
        {

        }
        public static ISys_DictionaryListRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_DictionaryListRepository>(); }
        }
    }
}

