using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startimes.Data.DataObjects.Startimes.Recharge
{
    public class PackageRechargeInfoViewModel
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
