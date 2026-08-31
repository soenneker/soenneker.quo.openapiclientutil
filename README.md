[![](https://img.shields.io/nuget/v/soenneker.quo.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.quo.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.quo.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.quo.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.quo.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.quo.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.quo.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.quo.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Quo.OpenApiClientUtil

Provides a lazily initialized Quo client for contacts, calls, messages, conversations, phone numbers, users, and webhooks.

## Installation

```bash
dotnet add package Soenneker.Quo.OpenApiClientUtil
```

## Configuration

```json
{
  "Quo": {
    "ApiKey": "your-api-key"
  }
}
```

Set `Quo:ClientBaseUrl` only when targeting a different Quo-compatible endpoint. The default is `https://api.openphone.com/` because Quo continues to serve its API from the OpenPhone domain.

## Usage

```csharp
using Soenneker.Quo.OpenApiClientUtil.Abstract;
using Soenneker.Quo.OpenApiClientUtil.Registrars;

services.AddQuoOpenApiClientUtilAsSingleton();

public sealed class QuoService
{
    private readonly IQuoOpenApiClientUtil _quo;

    public QuoService(IQuoOpenApiClientUtil quo)
    {
        _quo = quo;
    }

    public async Task GetUsers(CancellationToken cancellationToken)
    {
        var client = await _quo.Get(cancellationToken);
        var users = await client.V1.Users.GetAsync(
            cancellationToken: cancellationToken);
    }
}
```

Use `AddQuoOpenApiClientUtilAsScoped()` when each scope should have its own lazily initialized API client. Both registrations reuse the singleton authenticated HTTP client provider.
