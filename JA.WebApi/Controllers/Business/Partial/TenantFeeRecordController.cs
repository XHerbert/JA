/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *接口编写处...
 *如果接口需要做Action的权限验证，请在Action上使用属性
 *如: [ApiActionPermission("TenantFeeRecord",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using JA.Entity.DomainModels;
using JA.Business.IServices;
using Microsoft.AspNetCore.Authorization;
using JA.Core.ManageUser;
using JA.Core.Utilities;

namespace JA.Business.Controllers
{
    public partial class TenantFeeRecordController
    {
        private readonly ITenantFeeRecordService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITenantFeeRecordService _tenantFeeRecordService;

        [ActivatorUtilitiesConstructor]
        public TenantFeeRecordController(
            ITenantFeeRecordService service,
            IHttpContextAccessor httpContextAccessor,
            ITenantFeeRecordService tenantFeeRecordService
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _tenantFeeRecordService = tenantFeeRecordService;
        }

        [HttpGet]
        [Route("generatePeriodRentRecord")]
        public IActionResult GeneratePeriodRentRecord()
        {
            //TODO:生成本期期数，如202105
            WebResponseContent response = WebResponseContent.Instance;
            int result = _tenantFeeRecordService.GeneratePeriodRentRecord();
            if (result == 0)
            {
                return Json(response.Error("本月应收记录已生成！"));
            }
            
            //var data = _tenantFeeRecordService.GetPageData(new PageDataOptions { Order = "desc", Page = 1, Rows = 30, Sort = "Id" });
            return Json(response.OK($"{2021}期应收记录生成{result}条！",null));
        }


        [HttpGet]
        [Route("getMonthRentReport")]
        public IActionResult GetMonthRentReport()
        {
            WebResponseContent response = WebResponseContent.Instance;
            var data = _service.GetMonthRentReport(null);
            return Json(response.OK(null, data));
        }
    }
}
