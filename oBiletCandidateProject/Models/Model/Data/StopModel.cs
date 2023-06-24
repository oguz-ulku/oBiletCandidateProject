using System.Text.Json.Serialization;

namespace DataModels.Model
{
    public class StopModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("kolayCarLocationId")]
        public int? KolayCarLocationId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("station")]
        public string Station { get; set; }
        [JsonPropertyName("time")]
        public DateTime? Time { get; set; }
        [JsonPropertyName("is-origin")]
        public bool IsOrigin { get; set; }
        [JsonPropertyName("is-destination")]
        public bool IsDestination { get; set; }
    }
}
