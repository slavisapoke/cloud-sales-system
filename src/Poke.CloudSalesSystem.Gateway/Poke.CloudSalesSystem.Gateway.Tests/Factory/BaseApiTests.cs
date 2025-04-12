namespace Poke.CloudSalesSystem.Gateway.Tests.Factory;

public class BaseApiTests : IClassFixture<ApiTestFactory>
{
    protected readonly HttpClient _client;

    public BaseApiTests(ApiTestFactory factory)
    {
        _client = factory.CreateClient();
    }
}
