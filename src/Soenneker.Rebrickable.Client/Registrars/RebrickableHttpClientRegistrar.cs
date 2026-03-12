using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Rebrickable.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Rebrickable.Client.Registrars;

/// <summary>
/// A .NET thread-safe singleton HttpClient for GitHub
/// </summary>
public static class RebrickableHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="RebrickableHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRebrickableHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IRebrickableHttpClient, RebrickableHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="RebrickableHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddRebrickableHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IRebrickableHttpClient, RebrickableHttpClient>();

        return services;
    }
}
