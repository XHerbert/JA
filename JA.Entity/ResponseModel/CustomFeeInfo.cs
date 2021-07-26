using System;
using System.Collections.Generic;
using System.Text;

namespace JA.Entity.ResponseModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomFeeInfoResponse
    {
        /// <summary>
        /// 缴费专号
        /// </summary>
        public int CUST_ID { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CUST_NAME { get; set; }
        /// <summary>
        /// 客户地址
        /// </summary>
        public string HOME_ADDR { get; set; }
        /// <summary>
        /// 总欠费金额
        /// </summary>
        public int TOTAL_AMT { get; set; }
        /// <summary>
        /// 应缴金额
        /// </summary>
        public int TRAN_AMT { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public int BALANCE { get; set; }
        /// <summary>
        /// 欠费明细总条数
        /// </summary>
        public int DETAILNUM { get; set; }
    }
}
