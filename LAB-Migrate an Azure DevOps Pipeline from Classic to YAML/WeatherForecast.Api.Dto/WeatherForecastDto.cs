namespace WeatherForecast.Api.Dto;

public class WeatherForecastDto
{
    public string City { get; init; } = default!;
    public int TemperatureC { get; init; }
}