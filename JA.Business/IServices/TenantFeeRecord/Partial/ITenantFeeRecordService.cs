/*
*Author：xuhbd
*Contact：xuhbd@foxmail.com
*所有关于TenantFeeRecord类的业务代码接口应在此处编写
*/
using JA.Core.BaseProvider;
using JA.Entity.DomainModels;
using JA.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace JA.Business.IServices
{
    public partial interface ITenantFeeRecordService
    {
        /// <summary>
        /// 生成应收记录
        /// </summary>
        /// <returns></returns>
        int GeneratePeriodRentRecord();

        /// <summary>
        /// 获取月租金报表
        /// </summary>
        /// <returns></returns>
        List<object> GetMonthRentReport(string period = null);
    }
}
