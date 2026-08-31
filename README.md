[![](https://img.shields.io/nuget/v/soenneker.rebrickable.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.rebrickable.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.rebrickable.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.rebrickable.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.rebrickable.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.rebrickable.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.rebrickable.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.rebrickable.client/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Rebrickable.Client

Provides a cached `HttpClient` configured for Rebrickable's LEGO catalog and user-collection API.

## Installation

```bash
dotnet add package Soenneker.Rebrickable.Client
```

## Configuration

```json
{
  "Rebrickable": {
    "ApiKey": "your-api-key"
  }
}
```

The client uses `https://rebrickable.com/api/v3/` by default. Set `Rebrickable:ClientBaseUrl` only when routing through a proxy or compatible endpoint.

## Usage

```csharp
using Soenneker.Rebrickable.Client.Abstract;
using Soenneker.Rebrickable.Client.Registrars;

services.AddRebrickableHttpClientAsSingleton();

public sealed class RebrickableColorService
{
    private readonly IRebrickableHttpClient _rebrickable;

    public RebrickableColorService(IRebrickableHttpClient rebrickable)
    {
        _rebrickable = rebrickable;
    }

    public async Task<string> GetColors(CancellationToken cancellationToken)
    {
        HttpClient client = await _rebrickable.Get(cancellationToken);
        return await client.GetStringAsync("lego/colors/", cancellationToken);
    }
}
```

The provider sends `Authorization: key <api-key>` on every request, as required by Rebrickable. List endpoints are paginated; use their `next` response value or the `page` and `page_size` query parameters rather than assuming the first response is complete.
