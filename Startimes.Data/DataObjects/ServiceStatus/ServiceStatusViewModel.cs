using Newtonsoft.Json;

namespace Startimes.Data.DataObjects.Startimes
{
    public class ServiceStatusViewModel
    {
        [JsonProperty("service_status_desc")]
        public string? ServiceStatusDesc { get; set; }
    }
}
