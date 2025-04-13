using Microsoft.Extensions.Caching.Memory;
using Poke.CloudSalesSystem.Common.Contracts.Products;
using Poke.CloudSalesSystem.Products.Application.Handlers.Query.GetCase;
using Poke.CloudSalesSystem.Products.Application.Handlers.Query.GetCustomers;
using System.Data.Common;
using System.Threading;
using ZiggyCreatures.Caching.Fusion;

namespace Poke.CloudSalesSystem.Products.Tests.UnitTests.Handlers;

public class GetProductsQueryHandlerTests
{
    private readonly Mock<IProductsProvider> _productProviderMock = new();
    private readonly Mock<IProductProviderFactory>  _providerFactoryMock = new();
    private readonly GetProductsQueryHandler _sut;

    public GetProductsQueryHandlerTests()
    {
        var cache = new FusionCache(new FusionCacheOptions
        { 
            CacheName = nameof(GetProductsQueryHandlerTests) 
        }, 
        new MemoryCache(new MemoryCacheOptions()));

        _ = _providerFactoryMock
            .Setup(f => f.GetProvider(It.IsAny<Guid>()))
            .Returns(_productProviderMock.Object);

        _sut = new GetProductsQueryHandler(cache, _providerFactoryMock.Object);
    }

    [Fact]
    public async Task Handle_ActualProviderCall_IsInvokedOnce()
    {
        // Arrange
        var request = new GetProductsQuery(Guid.NewGuid());
        
        // Act
        _ = await _sut.Handle(request, new());

        // Assert
        _productProviderMock.Verify(pp => pp.GetAllProducts(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ActualProviderIsInvoked_ReturnsResult()
    {
        // Arrange
        var productName = "test";
        var product = new Product { Name = productName };
        var request = new GetProductsQuery(Guid.NewGuid());
        _ = _productProviderMock.Setup(s => s.GetAllProducts(It.IsAny<CancellationToken>()))
            .ReturnsAsync([product]);

        // Act
        var result = await _sut.Handle(request, new());

        // Assert
        _productProviderMock.Verify(pp => pp.GetAllProducts(It.IsAny<CancellationToken>()), Times.Once);
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.Should().Contain(c => c.Name == productName);
    }

    [Fact]
    public void Handle_WhenProviderThrowsException_ExceptionIsThrown()
    {
        // Arrange
        var request = new GetProductsQuery(Guid.NewGuid());
        _ = _productProviderMock.Setup(s => s.GetAllProducts(It.IsAny<CancellationToken>()))
           .ThrowsAsync(new DummyException());

        // Act
        var act = async () => await _sut.Handle(request, new());

        // Assert
        _ = act.Should().ThrowAsync<DummyException>();
    }

}
