using System.Text.Json.Serialization;

namespace DataModels.Model
{
    public class SessionResponse: DeviceSessionModel
    {
        [JsonPropertyName("affiliate")]
        public string Affiliate { get; set; }
        [JsonPropertyName("device-type")]
        public int DeviceType { get; set; }
        [JsonPropertyName("device")]
        public string Device { get; set; }
        [JsonPropertyName("ip-country")]
        public string IpCountry { get; set; }
    }
}
