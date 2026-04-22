using Soenneker.Rebrickable.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Rebrickable.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class RebrickableHttpClientTests : HostedUnitTest
{
    private readonly IRebrickableHttpClient _httpclient;

    public RebrickableHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IRebrickableHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
