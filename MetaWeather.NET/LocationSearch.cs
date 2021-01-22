using System.Text.Json.Serialization;

namespace MetaWeather.NET
{
    public class LocationSearch
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
        [JsonPropertyName("woeid")]
        public long WOEID { get; set; }
        [JsonPropertyName("distance")]
        public long Distance { get; set; }
    }
}