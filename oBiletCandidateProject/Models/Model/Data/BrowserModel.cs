using System.Text.Json.Serialization;

namespace DataModels.Model
{
    public class BrowserModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
