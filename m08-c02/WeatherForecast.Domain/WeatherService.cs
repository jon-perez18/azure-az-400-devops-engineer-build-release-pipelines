namespace WeatherForecast.Domain;

public class WeatherService : IWeatherService
{
    private readonly Random _random = new();

    public int GetAverageTemperature(string city, DateTimeOffset dateTimeOffset)
    {
        for (int i = 0; i < 100000; i++)
        {
            _random.Next();
        }
        return _random.Next(-10, 40);
    }
}
