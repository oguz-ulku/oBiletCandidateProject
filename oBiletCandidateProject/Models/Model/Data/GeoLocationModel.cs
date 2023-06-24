﻿using System.Text.Json.Serialization;

namespace DataModels.Model
{
    public class GeoLocationModel
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
        [JsonPropertyName("zoom")]
        public int Zoom { get; set; }
    }
}
