using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MetaWeather.NET
{
    public class CoordinateConverter : JsonConverter<Coordinate>
    {
        public override Coordinate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string latLongString = reader.GetString();
            if (string.IsNullOrWhiteSpace(latLongString) || !latLongString.Contains(","))
            {
                throw new JsonException("Could not convert latitude and longitude value");
            }
            string[] coordinateStrings = latLongString.Split(',');
            if (double.TryParse(coordinateStrings[0], out double latitude) && double.TryParse(coordinateStrings[1], out double longitude))
            {
                return new Coordinate { Latitude = latitude, Longitude = longitude };
            }
            throw new JsonException("Could not convert latitude and longitude value");
        }

        public override void Write(Utf8JsonWriter writer, Coordinate value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
