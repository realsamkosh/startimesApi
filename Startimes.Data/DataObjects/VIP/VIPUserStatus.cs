using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startimes.Data.DataObjects.VIP
{
    public class VIPUserStatus
    {
        [JsonProperty("msisdn")]
        public string? Msisdn { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("nickname")]
        public string? Nickname { get; set; }

        [JsonProperty("resultCode")]
        public string? ResultCode { get; set; }

        [JsonProperty("resultMessage")]
        public string? ResultMessage { get; set; }
    }
}
