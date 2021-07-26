using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JA.Entity.ResponseModel
{
    public class BaseResponse
    {
        [JsonProperty("STATUS")]
        public int STATUS { get; set; }
        public string MESSAGE { get; set; }

    }
}
