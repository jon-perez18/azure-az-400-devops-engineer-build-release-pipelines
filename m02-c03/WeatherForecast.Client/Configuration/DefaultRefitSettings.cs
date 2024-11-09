using Refit;
using System.Text.Json;

// ReSharper disable once CheckNamespace for discoverability of service collection extensions in external client projects
namespace Microsoft.Extensions.DependencyInjection;

public static class DefaultRefitSettings
{
    public static readonly RefitSettings Instance = new(new SystemTextJsonContentSerializer(new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }))
    {
        CollectionFormat = CollectionFormat.Multi
    };
}