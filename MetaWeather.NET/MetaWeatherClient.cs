using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MetaWeather.NET
{
    public class MetaWeatherClient : IMetaWeatherClient
    {
        public async Task<Location> Location(int WOEID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Forecast>> LocationDay(int WOEID, DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<LocationSearch> LocationSearch(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<LocationSearch> LocationSearch(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
