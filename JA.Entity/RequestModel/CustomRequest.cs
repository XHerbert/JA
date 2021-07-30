using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JA.Entity.RequestModel
{
    public class CustomRequest
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        [JsonProperty("CUST_ID")]
        public string CUST_ID { get; set; }
    }
}
