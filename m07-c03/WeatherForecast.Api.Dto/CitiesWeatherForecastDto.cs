namespace WeatherForecast.Api.Dto;

public class CitiesWeatherForecastDto
{
    public string City { get; init; } = default!;
    public int TemperatureC { get; init; }
}
