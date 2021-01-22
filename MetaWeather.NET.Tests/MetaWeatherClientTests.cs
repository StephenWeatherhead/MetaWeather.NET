using System;
using System.Threading.Tasks;
using Xunit;

namespace MetaWeather.NET.Tests
{
    public class MetaWeatherClientTests
    {
        [Fact]
        public async Task LocationSearchQuery()
        {
            LocationSearch locationSearch;
            using (var client = new MetaWeatherClient())
            {
                locationSearch = await client.LocationSearch("london");
            }
            Assert.Equal("London", locationSearch.Title);
            Assert.Equal("City", locationSearch.LocationType);
            Assert.Equal(44418, locationSearch.WOEID);
            Assert.Equal(51.51, Math.Round(locationSearch.Latitude, 2));
            Assert.Equal(-0.13, Math.Round(locationSearch.Longitude, 2));
        }
    }
}
