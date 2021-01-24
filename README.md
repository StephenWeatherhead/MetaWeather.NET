# MetaWeather.NET
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE.md)

MetaWeather.NET is a .NET Standard client library for [MetaWeather](https://www.metaweather.com/) - a weather forecast API. The library is released under an MIT license. An example of how to use the library is below. More examples can be found in the test project. For more details about the API, go to https://www.metaweather.com/api/

```csharp
Location location;
using (var client = new MetaWeatherClient())
{
    LocationSearch[] locationSearches = await client.LocationSearch("london");
    location = await client.Location(locationSearches[0].WOEID);
}
Console.WriteLine("The location is " + location.Title);
Console.WriteLine("The forecast is " + location.ConsolidatedWeather[0].WeatherStateName);
Console.WriteLine("The minimum temperature is " + location.ConsolidatedWeather[0].MinTemperature.ToString() + " degrees centigrade");
// The location is London
// The forecast is Light Cloud
// The minimum temperature is 5 degrees centigrade
```