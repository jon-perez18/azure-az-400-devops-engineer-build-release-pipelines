using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Api.Dto;
using WeatherForecast.Domain;

namespace WeatherForecast.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Cities = new[]
    {
        "Drachten", "Enschede"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet]
    public IReadOnlyCollection<WeatherForecastDto> Get()
    {
        var weatherForecasts = Cities
            .Select(city => new WeatherForecastDto
            {
                City = city,
                TemperatureC = _weatherService.GetAverageTemperature(city, DateTimeOffset.Now)
            })
            .ToArray();

        return weatherForecasts;
    }
}
