using System.Text.Json.Serialization;


namespace DataModels.Model
{
    public class SessionRequest
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("browser")]
        public BrowserModel Browser { get; set; }
        [JsonPropertyName("connection")]
        public ConnectionModel Connection { get; set; }
    }
}
