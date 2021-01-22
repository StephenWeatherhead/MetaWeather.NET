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
        private HttpClient _httpClient;
        public MetaWeatherClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "MetaWeather.NET");
        }
        public void Dispose()
        {
            _httpClient.Dispose();
        }

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
            string url = "https://www.metaweather.com/api/location/search/?query=" + HttpUtility.UrlEncode(query);
            var streamTask = _httpClient.GetStreamAsync(url);
            return (await JsonSerializer.DeserializeAsync<LocationSearch[]>(await streamTask))[0];
        }

        public async Task<LocationSearch> LocationSearch(double latitude, double longitude)
        {
            string latitudeString = HttpUtility.UrlEncode(latitude.ToString());
            string longitudeString = HttpUtility.UrlEncode(longitude.ToString());
            string url = "https://www.metaweather.com/api/location/search/?lattlong=" + latitudeString + "," + longitudeString;
            var streamTask = _httpClient.GetStreamAsync(url);
            return (await JsonSerializer.DeserializeAsync<LocationSearch[]>(await streamTask))[0];
        }
    }
}
