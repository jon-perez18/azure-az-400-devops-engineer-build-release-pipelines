using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace WeatherForecast.Client.UnitTest
{
    public class WeatherApiClientTest
    {
        [Fact]
        public async Task TestGetWeatherForecast()
        {
            var webApplicationFactory = new WebApplicationFactory<WeatherForecast.Api.Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.AddWeatherForecastClient();
                    });
                });

            var client = RestService.For<IWeatherApiClient>(webApplicationFactory.CreateClient());

            var result = await client.GetAsync();

            Assert.Equal(2, result!.Content!.Count);
        }
    }
}