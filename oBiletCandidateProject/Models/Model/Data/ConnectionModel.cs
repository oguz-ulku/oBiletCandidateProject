using System.Text.Json.Serialization;

namespace DataModels.Model
{
    public class ConnectionModel
    {
        [JsonPropertyName("ip-address")]
        public string IpAddress { get; set; }
        [JsonPropertyName("port")]
        public string Port { get; set; }
    }
}
