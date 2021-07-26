/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下VtenanthouserelationService与IVtenanthouserelationService中编写
 */
using JA.Business.IRepositories;
using JA.Business.IServices;
using JA.Core.BaseProvider;
using JA.Core.Extensions.AutofacManager;
using JA.Entity.DomainModels;

namespace JA.Business.Services
{
    public partial class VtenanthouserelationService : ServiceBase<Vtenanthouserelation, IVtenanthouserelationRepository>
    , IVtenanthouserelationService, IDependency
    {
    public VtenanthouserelationService(IVtenanthouserelationRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IVtenanthouserelationService Instance
    {
      get { return AutofacContainerModule.GetService<IVtenanthouserelationService>(); } }
    }
 }
