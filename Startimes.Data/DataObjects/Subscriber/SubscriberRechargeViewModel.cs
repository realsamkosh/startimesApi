using Newtonsoft.Json;

namespace Startimes.Data.DataObjects.Subscriber
{
    public class SubscriberRechargeViewModel
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
