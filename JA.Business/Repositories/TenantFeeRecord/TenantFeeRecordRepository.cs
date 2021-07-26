/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹TenantFeeRecordRepository编写代码
 */
using JA.Business.IRepositories;
using JA.Core.BaseProvider;
using JA.Core.EFDbContext;
using JA.Core.Extensions.AutofacManager;
using JA.Entity.DomainModels;

namespace JA.Business.Repositories
{
    public partial class TenantFeeRecordRepository : RepositoryBase<TenantFeeRecord> , ITenantFeeRecordRepository
    {
        public TenantFeeRecordRepository(JAContext dbContext)
        : base(dbContext)
        {

        }
        public static ITenantFeeRecordRepository Instance
        {
          get {  return AutofacContainerModule.GetService<ITenantFeeRecordRepository>(); } 
        }
    }
}
