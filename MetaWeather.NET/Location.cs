using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MetaWeather.NET
{
    public class Location
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }
        [JsonIgnore()]
        public double Latitude { get { return Coordinate.Latitude; } }
        [JsonIgnore()]
        public double Longitude { get { return Coordinate.Longitude; } }
        [JsonPropertyName("latt_long"), JsonConverter(typeof(CoordinateConverter))]
        public Coordinate Coordinate { get; set; }
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("sun_rise")]
        public DateTime Sunrise { get; set; }
        [JsonPropertyName("sun_set")]
        public DateTime Sunset { get; set; }
        [JsonPropertyName("timezone")]
        public string TimeZoneName { get; set; }
        [JsonPropertyName("parent")]
        public ParentLocation Parent { get; set; }
        [JsonPropertyName("consolidated_weather")]
        public Forecast[] ConsolidatedWeather { get; set; }
        [JsonPropertyName("sources")]
        public Source[] Sources { get; set; }
    }
}