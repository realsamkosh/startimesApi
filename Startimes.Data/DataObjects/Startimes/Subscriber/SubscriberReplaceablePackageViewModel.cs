using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startimes.Data.DataObjects.Startimes.Subscriber
{
    public class SubscriberReplaceablePackageViewModel
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
