using DataModels.Constants;
using System.Text.Json.Serialization;


namespace DataModels.Model
{
    public class ApiRequest<T>
    {
        [JsonPropertyName("language")]
        public string Language { get; set; } = GeneralConstant.Turkish;
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("device-session")]
        public DeviceSessionModel DeviceSession { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
