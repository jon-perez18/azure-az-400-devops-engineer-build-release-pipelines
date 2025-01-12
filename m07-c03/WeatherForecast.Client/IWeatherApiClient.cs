using Refit;
using WeatherForecast.Api.Dto;

namespace WeatherForecast.Client;

public interface IWeatherApiClient
{
    [Get("/api/weatherforecast")]
    Task<IApiResponse<IReadOnlyCollection<CitiesWeatherForecastDto>>> GetAsync(CancellationToken token = default);
}
