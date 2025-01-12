using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using WeatherForecast.Api.Dto;
using WeatherForecast.Domain;

namespace WeatherForecast.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class WeatherForecastController: ControllerBase
{
    private static readonly string[] Cities = new[]
    {
        "Drachten", "Enschede"
    };

    private static readonly string[] Countries = new[]
{
        "Netherlands", "Germany"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;
    private readonly IFeatureManager _featureManager;
    private readonly IConfiguration _configuration;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService, IFeatureManager featureManager, IConfiguration configuration)
    {
        _logger = logger;
        _weatherService = weatherService;
        _featureManager = featureManager;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var citiesWeatherForecasts = Cities
            .Select(city => new CitiesWeatherForecastDto
            {
                City = city,
                TemperatureC = _weatherService.GetAverageTemperature(city, DateTimeOffset.Now)
            })
            .ToArray();

        if (! await _featureManager.IsEnabledAsync("include-countries"))
        {
            return Ok(citiesWeatherForecasts);
        }

        var countriesWeatherForecasts = Countries
            .Select(country => new CountriesWeatherForecastDto
            {
                Country = country,
                TemperatureC = _weatherService.GetAverageTemperature(country, DateTimeOffset.Now)
            });

        return Ok(new
        {
            Cities = citiesWeatherForecasts,
            Countries = countriesWeatherForecasts
        });
    }
}
