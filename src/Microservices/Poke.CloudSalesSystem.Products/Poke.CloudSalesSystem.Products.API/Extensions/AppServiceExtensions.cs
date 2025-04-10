using Poke.CloudSalesSystem.Products.Application;

namespace Poke.CloudSalesSystem.Products.API.Extensions;

public static class AppServiceExtensions
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterApplication(configuration);

        return services;
    }
}
