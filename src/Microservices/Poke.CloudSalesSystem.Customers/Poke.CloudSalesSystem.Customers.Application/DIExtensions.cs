using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Customers.Application.Pipeline;

namespace Poke.CloudSalesSystem.Customers.Application;

public static class DIExtensions
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DIExtensions).Assembly);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DIExtensions).Assembly);
            configuration.AddOpenBehavior(typeof(LogBehavior<,>));
        });

        return services;
    }
}