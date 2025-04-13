using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Common.Cache.Fusion.Extensions;
using Poke.CloudSalesSystem.Common.CloudComputingClient;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;
using Poke.CloudSalesSystem.Common.MediatR.Pipeline;
using Poke.CloudSalesSystem.Products.Application.Abstract;
using Poke.CloudSalesSystem.Products.Application.Adapters;

namespace Poke.CloudSalesSystem.Products.Application;

public static class DIExtensions
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DIExtensions).Assembly);

        services.RegisterProductProvides(configuration);
        services.RegisterFusionCache(configuration);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DIExtensions).Assembly);
            configuration.AddOpenBehavior(typeof(LogBehavior<,>));
        });

        return services;
    }

    public static IServiceCollection RegisterProductProvides(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICloudComputingProvider, CloudComputingProvider>();
        services.AddTransient<IProductProviderFactory, ProductProviderFactory>();

        return services;
    }
}