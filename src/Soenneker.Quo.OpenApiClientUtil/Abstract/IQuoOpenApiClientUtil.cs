using Soenneker.Quo.OpenApiClient;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Quo.OpenApiClientUtil.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for 
/// </summary>
public interface IQuoOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<QuoOpenApiClient> Get(CancellationToken cancellationToken = default);
}
