namespace WeatherForecast.Api.Dto;

public class CountriesWeatherForecastDto
{
    public string Country { get; init; } = default!;
    public int TemperatureC { get; init; }
}