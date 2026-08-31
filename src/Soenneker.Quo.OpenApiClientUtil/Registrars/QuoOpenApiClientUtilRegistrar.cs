using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Quo.HttpClients.Registrars;
using Soenneker.Quo.OpenApiClientUtil.Abstract;

namespace Soenneker.Quo.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized Quo API client.
/// </summary>
public static class QuoOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Quo API client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddQuoOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddQuoOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IQuoOpenApiClientUtil, QuoOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Quo API client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddQuoOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddQuoOpenApiHttpClientAsSingleton()
                .TryAddScoped<IQuoOpenApiClientUtil, QuoOpenApiClientUtil>();

        return services;
    }
}
