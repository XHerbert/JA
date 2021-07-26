/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下DepartmentService与IDepartmentService中编写
 */
using JA.Business.IRepositories;
using JA.Business.IServices;
using JA.Core.BaseProvider;
using JA.Core.Extensions.AutofacManager;
using JA.Entity.DomainModels;

namespace JA.Business.Services
{
    public partial class DepartmentService : ServiceBase<Department, IDepartmentRepository>
    , IDepartmentService, IDependency
    {
    public DepartmentService(IDepartmentRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IDepartmentService Instance
    {
      get { return AutofacContainerModule.GetService<IDepartmentService>(); } }
    }
 }
