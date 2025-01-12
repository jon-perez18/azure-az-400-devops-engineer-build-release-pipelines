using WeatherForecast.Domain;
using Microsoft.FeatureManagement;
using Azure.Identity;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
namespace WeatherForecast.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<IWeatherService, WeatherService>();


        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAzureAppConfiguration();
        builder.Services.AddFeatureManagement();

        builder.Configuration.AddAzureAppConfiguration(options =>
        {
            options.Connect(new Uri("https://weatherforecast-hb-test.azconfig.io"), new DefaultAzureCredential(new DefaultAzureCredentialOptions { TenantId = "c570bc0b-9ef3-4b15-98fc-9d7ca9b22afe" }))
            .Select("*", LabelFilter.Null)
            .ConfigureRefresh(refreshOptions =>
            {
                refreshOptions.Register("*", refreshAll: true);
                refreshOptions.SetRefreshInterval(TimeSpan.FromSeconds(5));
            });

            options.UseFeatureFlags(featureFlagOptions =>
            {
                featureFlagOptions.SetRefreshInterval(TimeSpan.FromSeconds(5));
                featureFlagOptions.Select("*", LabelFilter.Null);
            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseAzureAppConfiguration();

        app.Run();
    }
}
