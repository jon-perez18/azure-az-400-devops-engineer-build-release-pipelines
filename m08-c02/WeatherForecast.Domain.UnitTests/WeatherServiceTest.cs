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

        [Fact]
        public void FlakyTest()
        {
            var randomValue = new Random().Next(0, 3);

            Assert.True(randomValue != 1);
        }
    }
}