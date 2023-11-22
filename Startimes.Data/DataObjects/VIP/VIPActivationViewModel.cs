using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startimes.Data.DataObjects.VIP
{
    public class VIPActivationViewModel
    {
        [JsonProperty("reference")]
        public string? Reference { get; set; }

        [JsonProperty("transactionId")]
        public string? TransactionId { get; set; }

        [JsonProperty("resultCode")]
        public string? ResultCode { get; set; }

        [JsonProperty("resultMessage")]
        public string? ResultMessage { get; set; }
    }
}
