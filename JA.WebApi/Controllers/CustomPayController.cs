using JA.Entity.RequestModel;
using JA.Entity.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MicrosoftSystemIO = System.IO;
using System.Linq;
using System.Threading.Tasks;
using JA.Core.Services;
using System.IO;
using Newtonsoft.Json;
using JA.Business.Services;
using JA.Entity.DomainModels;
using JA.Business.Repositories;
using System.Linq.Expressions;
using JA.Core.Utilities;

namespace JA.WebApi.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Consumes("application/json", "multipart/form-data")]
    [Route("api/customPay")]
    public class CustomPayController : Controller
    {
        /// <summary>
        /// 缴费接口
        /// </summary>
        /// <param name="customPayRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PayRentFee")]
        public IActionResult PayRentFee([FromBody] CustomPayRequest customPayRequest)
        {
            Logger.Info(Core.Enums.LoggerType.Info, JsonConvert.SerializeObject(customPayRequest));

            //TODO:根据专号和账期查询缴费记录 【1107060611301】如果是TenantCode需要根据Code查询Id

            Tenant tenant = TenantRepository.Instance.Find(t => t.TenantCode == customPayRequest.CUST_ID).FirstOrDefault();

            TenantFee tf = TenantFeeRepository.Instance.Find(predicate => predicate.Period == customPayRequest.DL_TERM && predicate.TenantId == tenant.Id).FirstOrDefault();

            if (null == tf)
            {
                WebResponseContent response = WebResponseContent.Instance;
                return Json(response.Error($"【{customPayRequest.CUST_ID}】不存在！"));
            }

            //TODO:更新缴费状态
            int hasPaid = 2;

            TenantFee t = new TenantFee
            {
                Id = tf.Id,
                PayStatus = hasPaid,
                ActualPaidRent = customPayRequest.TX_AMOUNT
            };

            //更新字段
            Expression<Func<TenantFee, object>> expTree = x => new { x.PayStatus, x.ActualPaidRent };
            TenantFeeRepository.Instance.Update(t, expTree, true);

            //TODO:按账期存储缴费记录，并计算欠费或余额数

            return Json(new BaseResponse { STATUS = 1, MESSAGE = "缴费成功" });
        }

        /// <summary>
        /// 查询接口，客户姓名 账户余额 账期 账单金额 客户地址，账单金额是需要缴费的金额，账单金额与账户余额有一个必然是0
        /// </summary>
        /// <param name="customRequest">客户ID号</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Query")]
        public IActionResult QueryRentFee([FromBody] CustomRequest customRequest)
        {
            //这里可以直接从生成的缴费清单中获取
            Tenant tenant = TenantRepository.Instance.Find(t => t.TenantCode == customRequest.CUST_ID).FirstOrDefault();
            if (null == tenant)
            {
                WebResponseContent response = WebResponseContent.Instance;
                return Json(response.Error($"【{customRequest.CUST_ID}】不存在！"));
            }

            Logger.Info(Core.Enums.LoggerType.Info, JsonConvert.SerializeObject(customRequest));

            //获取全部账期的数据
            var tenantFeeList = TenantFeeRepository.Instance.Find(f => f.TenantId == tenant.Id);
            if (null == tenantFeeList || tenantFeeList.Count == 0)
            {
                return Json(new BaseResponse { STATUS = 0, MESSAGE = "暂无数据" });
            }

            decimal? arrearage = 0, balance = 0;

            List<TermBill> termBills = new List<TermBill>();
            tenantFeeList.ForEach(item =>
            {
                TermBill bill = new TermBill()
                {
                    term = item.Period,
                    //实际支付
                    ActualPaidRent = item.ActualPaidRent,
                    //应收（房屋当期租金）
                    Receivable = item.Receivable,
                    //欠费（租金减去实际支付）
                    UnPaidRent = item.Receivable - item.ActualPaidRent
                };
                //欠费金额汇总
                arrearage += bill.UnPaidRent;
                //余额汇总
                balance = arrearage > 0 ? 0 : Math.Abs((decimal)arrearage);
                arrearage = balance > 0 ? 0 : arrearage * (-1);
                termBills.Add(bill);
            });

            var data = new CustomBillInfo { Address = tenant.Address, Arrearage = arrearage, Balance = balance, TenantId = tenant.Id, TenantName = tenant.TenantName, TermBill = termBills };
            return Json(new BaseResponse { STATUS = 1, MESSAGE = "成功", DATA = data });
        }

        /// <summary>
        /// 对账文件上传
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Transfer")]
        public IActionResult PostText([FromForm] IFormCollection keyValuePairs)
        {
            try
            {
                FormFileCollection formFiles = (FormFileCollection)keyValuePairs.Files;
                FormFile file = (FormFile)formFiles[0];
                StreamReader reader = new StreamReader(formFiles[0].OpenReadStream());
                string content = reader.ReadToEnd();
                Logger.Info(content);
                string name = file.FileName;
                string fileName = Path.Combine(@"Upload", name);
                using (FileStream fs = MicrosoftSystemIO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                //TODO:针对对账文件的读取与处理
                return Content("upload and save success!");
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return Content("upload failed!");
            }
        }
    }
}
