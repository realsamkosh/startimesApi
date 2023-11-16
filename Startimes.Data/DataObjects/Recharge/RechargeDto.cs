using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startimes.Data.DataObjects.Recharge
{
    public class RechargeDto
    {
        [JsonProperty("serial_no")]
        public string? SerialNo { get; set; }

        [JsonProperty("transaction_time")]
        public string? TransactionTime { get; set; }

        [JsonProperty("service_code")]
        public string? ServiceCode { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("new_package_code")]
        public string? NewPackageCode { get; set; }

        [JsonProperty("mobile")]
        public string? Mobile { get; set; }
    }
}
