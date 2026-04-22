using Soenneker.Quo.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Quo.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class QuoOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IQuoOpenApiClientUtil _openapiclientutil;

    public QuoOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IQuoOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
