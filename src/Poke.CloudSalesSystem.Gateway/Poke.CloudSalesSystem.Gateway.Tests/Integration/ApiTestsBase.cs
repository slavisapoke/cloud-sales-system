using FluentAssertions;
using Poke.CloudSalesSystem.Gateway.Tests.Factory;
using System.Net;
namespace Poke.CloudSalesSystem.Gateway.Tests.Integration;

/// <summary>
/// Add bunch of sofisticated controller tests
/// </summary>
public class ApiTestsBase : BaseApiTests
{
    public ApiTestsBase(ApiTestFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Get_Returns_OK()
    {
        // Act
        var response = await _client.GetAsync($"accounts/get-by-customer/{It.IsAny<Guid>()}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNull();
    }
}
