using System.Text.Json.Serialization;

namespace DataModels.Model
{
    public class DeviceSessionModel
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }
        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
    }
}
