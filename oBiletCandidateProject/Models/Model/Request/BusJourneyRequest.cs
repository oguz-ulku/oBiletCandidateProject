using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModels.Model
{
    public class BusJourneyRequest
    {
        [JsonPropertyName("origin-id")]
        public int OriginId { get; set; }
        [JsonPropertyName("destination-id")]
        public int DestinationId { get; set; }
        [JsonPropertyName("departure-date")]
        public string DepartureDate { get; set; }
    }
}
