namespace Startimes.Data.DataObjects.VIP
{
    public class VIPActivationDto
    {
        public string? NonceStr { get; set; }
        public string? SignType { get; set; }
        public string? Sign { get; set; }
        public string? RequestTime { get; set; }
        public string? Msisdn { get; set; }
        public string? SubscriptionId { get; set; }
        public string? Reference { get; set; }
        public string? Amount { get; set; }
        public string? Currency { get; set; }
    }
}
