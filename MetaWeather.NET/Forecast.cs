using System;

namespace MetaWeather.NET
{
    public class Forecast
    {
        public int ID { get; set; }
        public DateTime ApplicableDate { get; set; }
        public string WeatherStateName { get; set; }
        public string WeatherStateAbbreviation { get; set; }
        public double WindSpeed { get; set; }
        public double WindDirection { get; set; }
        public string WindDirectionCompass { get; set; }
        public double Temperature { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double AirPressure { get; set; }
        public double Humidity { get; set; }
        public double Visibility { get; set; }
        public double Predictability { get; set; }
    }
}