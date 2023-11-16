using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startimes.Data.DataObjects.Startimes.Recharge
{
    public class RechargeViewModel
    {
        [JsonProperty("basic_offer_display_name")]
        public string? BasicOfferDisplayName { get; set; }

        [JsonProperty("basic_offer_expiration_date")]
        public string? BasicOfferExpirationDate { get; set; }
    }
}
