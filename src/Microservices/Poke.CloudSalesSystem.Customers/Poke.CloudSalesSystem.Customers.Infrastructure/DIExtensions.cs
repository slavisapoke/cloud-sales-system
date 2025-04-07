using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Poke.CloudSalesSystem.Customers.Infrastructure;

public static class DIExtensions
{
    public static IServiceCollection RegisterInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        //.net8 preview contains TimeProvider.System
        services.AddScoped<TimeProvider, CustomTimeProvider>();

        return services;
    }
}
