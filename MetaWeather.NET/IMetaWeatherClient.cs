using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MetaWeather.NET
{
    public interface IMetaWeatherClient : IDisposable
    {
        Task<LocationSearch[]> LocationSearch(string query);
        Task<LocationSearch[]> LocationSearch(double latitude, double longitude);
        Task<Location> Location(int WOEID);
        Task<Forecast[]> LocationDay(int WOEID, DateTime date);
    }
}
