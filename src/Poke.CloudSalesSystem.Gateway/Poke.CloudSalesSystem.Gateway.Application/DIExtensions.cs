using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Poke.CloudSalesSystem.Gateway.Application;

public static class DIExtensions
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DIExtensions).Assembly);

        return services;
    }
}