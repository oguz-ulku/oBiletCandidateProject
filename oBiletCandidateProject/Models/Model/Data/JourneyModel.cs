using System.Text.Json.Serialization;

namespace DataModels.Model
{
    public class JourneyModel
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("stops")]
        public List<StopModel> Stops { get; set; }
        [JsonPropertyName("origin")]
        public string Origin { get; set; }
        [JsonPropertyName("destination")]
        public string Destination { get; set; }
        [JsonPropertyName("departure")]
        public DateTime Departure { get; set; }
        [JsonPropertyName("arrival")]
        public DateTime Arrival { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        [JsonPropertyName("original-price")]
        public decimal? OriginalPrice { get; set; }
        [JsonPropertyName("internet-price")]
        public decimal? InternetPrice { get; set; }
        [JsonPropertyName("provider-internet-price")]
        public decimal? ProviderInternetPrice { get; set; }
        [JsonPropertyName("booking")]
        public string[] Booking { get; set; }
        [JsonPropertyName("bus-name")]
        public string BusName { get; set; }
        [JsonPropertyName("policy")]
        public PolicyModel Policy { get; set; }
        [JsonPropertyName("features")]
        public string[] Features { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("available")]
        public string Available { get; set; }

    }
}
