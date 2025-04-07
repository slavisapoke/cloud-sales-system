using Poke.CloudSalesSystem.Customers.Infrastructure;
using Poke.CloudSalesSystem.Customers.Application;

namespace Poke.CloudSalesSystem.Customers.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterApplication(configuration);
        services.RegisterInfrastructure(configuration);

        return services;
    }
}
