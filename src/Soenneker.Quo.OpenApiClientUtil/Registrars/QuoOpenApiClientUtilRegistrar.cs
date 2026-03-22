using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Quo.HttpClients.Registrars;
using Soenneker.Quo.OpenApiClientUtil.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Quo.OpenApiClientUtil.Registrars;

/// <summary>
/// A .NET thread-safe singleton HttpClient for GitHub
/// </summary>
public static class QuoOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="QuoOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddQuoOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddQuoOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IQuoOpenApiClientUtil, QuoOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="QuoOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddQuoOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddQuoOpenApiHttpClientAsSingleton()
                .TryAddScoped<IQuoOpenApiClientUtil, QuoOpenApiClientUtil>();

        return services;
    }
}
