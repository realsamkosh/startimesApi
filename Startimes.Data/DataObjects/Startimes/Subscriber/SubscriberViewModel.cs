using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startimes.Data.DataObjects.Startimes.Subscriber
{
    public class SubscriberViewModel
    {
        [JsonProperty("subscriber_id")]
        public int SubscriberId { get; set; }

        [JsonProperty("service_code")]
        public string? ServiceCode { get; set; }

        [JsonProperty("customer_name")]
        public string? CustomerName { get; set; }

        [JsonProperty("mobile")]
        public string? Mobile { get; set; }

        [JsonProperty("contact_address")]
        public string? ContactAddress { get; set; }

        [JsonProperty("subscriber_status")]
        public string? SubscriberStatus { get; set; }

        [JsonProperty("expiration_date")]
        public string? ExpirationDate { get; set; }

        [JsonProperty("basic_offer_display_name")]
        public string? BasicOfferDisplayName { get; set; }

        [JsonProperty("basic_offer_business_class")]
        public string? BasicOfferBusinessClass { get; set; }

        [JsonProperty("other_info")]
        public string? OtherInfo { get; set; }
    }
}
