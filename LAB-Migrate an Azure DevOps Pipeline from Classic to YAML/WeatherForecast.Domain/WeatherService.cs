namespace WeatherForecast.Domain;

public class WeatherService : IWeatherService
{
    private readonly Random _random = new();

    public int GetAverageTemperature(string city, DateTimeOffset dateTimeOffset)
    {
        return _random.Next(-10, 40);
    }
}
