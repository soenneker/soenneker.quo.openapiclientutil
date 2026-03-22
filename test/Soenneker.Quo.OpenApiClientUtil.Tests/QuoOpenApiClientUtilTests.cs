using Soenneker.Quo.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Quo.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class QuoOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IQuoOpenApiClientUtil _openapiclientutil;

    public QuoOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IQuoOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
