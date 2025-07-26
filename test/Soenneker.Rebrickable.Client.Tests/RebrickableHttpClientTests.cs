using Soenneker.Rebrickable.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Rebrickable.Client.Tests;

[Collection("Collection")]
public sealed class RebrickableHttpClientTests : FixturedUnitTest
{
    private readonly IRebrickableHttpClient _httpclient;

    public RebrickableHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IRebrickableHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
