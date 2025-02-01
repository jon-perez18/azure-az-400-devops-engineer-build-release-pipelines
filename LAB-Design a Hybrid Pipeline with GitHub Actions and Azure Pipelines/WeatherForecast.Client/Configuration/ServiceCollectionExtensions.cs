using WeatherForecast.Client;
using Refit;

// ReSharper disable once CheckNamespace for discoverability of service collection extensions in external client projects
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeatherForecastClient(this IServiceCollection services)
    {
        services.AddRefitClient<IWeatherApiClient>(DefaultRefitSettings.Instance)
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:5001"));

        return services;
    }
}
