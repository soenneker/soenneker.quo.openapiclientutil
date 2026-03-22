using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Quo.OpenApiClientUtil.Abstract;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Quo.HttpClients.Abstract;
using Soenneker.Quo.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Quo.OpenApiClientUtil;

///<inheritdoc cref="IQuoOpenApiClientUtil"/>
public sealed class QuoOpenApiClientUtil : IQuoOpenApiClientUtil
{
    private readonly AsyncSingleton<QuoOpenApiClient> _client;

    public QuoOpenApiClientUtil(IQuoOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<QuoOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Quo:ApiKey");

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: apiKey), httpClient: httpClient);

            return new QuoOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<QuoOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
