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

        public async Task<Location> Location(long WOEID)
        {
            string url = "https://www.metaweather.com/api/location/" + HttpUtility.UrlEncode(WOEID.ToString()) + "/";
            var streamTask = _httpClient.GetStreamAsync(url);
            return (await JsonSerializer.DeserializeAsync<Location>(await streamTask));
        }

        public async Task<Forecast[]> LocationDay(int WOEID, DateTime date)
        {
            string url = $"https://www.metaweather.com/api/location/{HttpUtility.UrlEncode(WOEID.ToString())}/{date.Year.ToString()}/{date.Month.ToString()}/{date.Day.ToString()}/";
            var streamTask = _httpClient.GetStreamAsync(url);
            return (await JsonSerializer.DeserializeAsync<Forecast[]>(await streamTask));
        }

        public async Task<LocationSearch[]> LocationSearch(string query)
        {
            string url = "https://www.metaweather.com/api/location/search/?query=" + HttpUtility.UrlEncode(query);
            var streamTask = _httpClient.GetStreamAsync(url);
            return (await JsonSerializer.DeserializeAsync<LocationSearch[]>(await streamTask));
        }

        public async Task<LocationSearch[]> LocationSearch(double latitude, double longitude)
        {
            string coordinate = HttpUtility.UrlEncode(latitude.ToString() + "," + longitude.ToString());
            string url = "https://www.metaweather.com/api/location/search/?lattlong=" + coordinate;
            var streamTask = _httpClient.GetStreamAsync(url);
            return (await JsonSerializer.DeserializeAsync<LocationSearch[]>(await streamTask));
        }
    }
}
