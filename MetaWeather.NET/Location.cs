using System;
using System.Collections.Generic;

namespace MetaWeather.NET
{
    public class Location
    {
        public string Title { get; set; }
        public string LocationType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Time { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public string TimeZoneName { get; set; }
        public ParentLocation Parent { get; set; }
        public List<Forecast> ConsolidatedWeather { get; set; }
        public List<Source> Sources { get; set; }
    }
}