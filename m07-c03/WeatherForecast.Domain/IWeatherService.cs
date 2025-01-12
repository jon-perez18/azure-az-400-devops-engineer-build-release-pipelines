namespace WeatherForecast.Domain;

public interface IWeatherService
{
    public int GetAverageTemperature(string city, DateTimeOffset dateTimeOffset);
}
