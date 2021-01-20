using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace RetweetBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "My Repository Reporter");
            var myRepos = client.GetStringAsync("https://api.github.com/users/StephenWeatherhead/repos");
            Console.WriteLine(await myRepos);
            Console.ReadLine();
        }
    }
}
