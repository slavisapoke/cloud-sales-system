using AutoMapper;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;

namespace Poke.CloudSalesSystem.Products.Tests.UnitTests.Adapters;

public class ProductProviderFactoryTests
{
    private readonly Mock<IServiceProvider> _serviceProvider = new();
    private readonly Mock<ICloudComputingProvider> _ccProvider = new();
    private readonly Mock<IMapper> _mapper = new();
    private readonly ProductProvidersConfiguration _configuration;
    private readonly ProductProviderFactory _sut;

    public ProductProviderFactoryTests()
    {
        _configuration = new ProductProvidersConfiguration
        {
            CloudComputing = Guid.NewGuid(),
            SomeOtherProvider = Guid.NewGuid()
        };

        _ = _serviceProvider.Setup(sp => sp.GetService(typeof(ICloudComputingProvider)))
                    .Returns(_ccProvider.Object);
        _ = _serviceProvider.Setup(sp => sp.GetService(typeof(IMapper)))
                    .Returns(_mapper.Object);

        _sut = new ProductProviderFactory(_serviceProvider.Object, _configuration);
    }

    [Fact]
    public void GetProvider_CCP_ReturnsCorrectPovider()
    {
        // Arrange

        // Act
        var result = _sut.GetProvider(_configuration.CloudComputing);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<CloudComputingAdapter>();
    }

    [Fact]
    public void GetProvider_CCP_WhenCCPIsNotRegistered_ThrowsArgumentException()
    {
        // Arrange
        _ = _serviceProvider.Setup(sp => sp.GetService(typeof(ICloudComputingProvider)))
                    .Returns(default(ICloudComputingProvider?));

        // Act
        var act = () => _sut.GetProvider(_configuration.CloudComputing);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GetProvider_CCP_WhenMapperIsNotRegistered_ThrowsArgumentException()
    {
        // Arrange
        _ = _serviceProvider.Setup(sp => sp.GetService(typeof(IMapper)))
                    .Returns(default(IMapper?));

        // Act
        var act = () => _sut.GetProvider(_configuration.CloudComputing);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GetProvider_InvalidProvider_ThrowsNotSupportedExceptionException()
    {
        // Arrange
        var unrecognizedProviderId = Guid.NewGuid();

        // Act
        var act = () => _sut.GetProvider(unrecognizedProviderId);

        // Assert
        act.Should().Throw<NotSupportedException>().WithMessage($"Invalid products provider Id: {unrecognizedProviderId}");
    }
}
