using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.Rebrickable.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Rebrickable.Client;

///<inheritdoc cref="IRebrickableHttpClient"/>
public sealed class RebrickableHttpClient : IRebrickableHttpClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _config;

    public RebrickableHttpClient(IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;
        _config = config;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        // No closure: state passed explicitly + static lambda
        return _httpClientCache.Get(nameof(RebrickableHttpClient), _config, static config =>
        {
            var apiKey = config.GetValueStrict<string>("Rebrickable:ApiKey");

            return new HttpClientOptions
            {
                DefaultRequestHeaders = new Dictionary<string, string>
                {
                    {"Authorization", $"key {apiKey}"},
                }
            };
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(RebrickableHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(RebrickableHttpClient));
    }
}
