using Microsoft.AspNetCore.Mvc.Testing;

namespace WeatherForecast.Api.IntegrationTests
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public async Task GET_Weatherforecast()
        {
            using var factory = new WebApplicationFactory<Program>();
            using var client = factory.CreateClient();
            using var response = await client.GetAsync("/api/weatherforecast");

            response.EnsureSuccessStatusCode();
        }
    }
}