using System;
using System.Collections.Generic;
using System.Text;

namespace JA.Entity.ResponseModel
{
    public class CustomBillInfo
    {

        //账单金额是需要缴费的金额，账单金额与账户余额有一个必然是0


        /// <summary>
        /// 租客ID
        /// </summary>
        public int TenantId { get; set; }
        /// <summary>
        /// 租客姓名
        /// </summary>
        public string TenantName { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 账单金额（欠费）
        /// </summary>
        public decimal Arrearage { get; set; }
        /// <summary>
        /// 账期
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// 客户地址
        /// </summary>
        public string Address { get; set; }

    }
}
