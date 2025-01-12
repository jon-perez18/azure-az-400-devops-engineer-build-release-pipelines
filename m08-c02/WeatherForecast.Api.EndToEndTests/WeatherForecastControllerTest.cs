namespace WeatherForecast.Api.EndToEndTests
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public async Task GET_Weatherforecast()
        {
            var client = new HttpClient();

            var response = await client.GetAsync("https://weatherforecast-hb-test.azurewebsites.net/api/weatherforecast");

            response.EnsureSuccessStatusCode();
        }
    }
}