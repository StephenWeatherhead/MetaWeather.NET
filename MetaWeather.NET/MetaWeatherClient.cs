using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

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
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "MetaWeather.NET");
            string url = "https://www.metaweather.com/api/location/search/?query=" + HttpUtility.UrlEncode(query);
            var streamTask = client.GetStreamAsync(url);
            return (await JsonSerializer.DeserializeAsync<LocationSearch[]>(await streamTask))[0];
        }

        public async Task<LocationSearch> LocationSearch(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
