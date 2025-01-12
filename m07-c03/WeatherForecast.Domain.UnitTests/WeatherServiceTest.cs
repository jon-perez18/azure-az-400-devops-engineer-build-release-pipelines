namespace WeatherForecast.Domain.UnitTests
{
    public class WeatherServiceTest
    {
        [Fact]
        public void Test1()
        {
            var service = new WeatherService();

            var result = service.GetAverageTemperature("London", DateTimeOffset.Now);

            Assert.InRange(result, -10, 40);
        }
    }
}