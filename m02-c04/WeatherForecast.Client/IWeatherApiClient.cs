using Refit;
using WeatherForecast.Api.Dto;

namespace WeatherForecast.Client;

public interface IWeatherApiClient
{
    [Get("/api/weatherforecast")]
    Task<IApiResponse<IReadOnlyCollection<WeatherForecastDto>>> GetAsync(CancellationToken token = default);
}
