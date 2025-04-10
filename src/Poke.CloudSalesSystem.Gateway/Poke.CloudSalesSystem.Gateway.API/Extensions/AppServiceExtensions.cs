using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Common.Contracts.Licences;
using Poke.CloudSalesSystem.Gateway.API.Authorization;
using Poke.CloudSalesSystem.Gateway.Application;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;
using Poke.CloudSalesSystem.Gateway.Application.Configuration;
using Poke.CloudSalesSystem.Gateway.Application.Constants;
using Poke.CloudSalesSystem.Gateway.Infrastructure;

namespace Poke.CloudSalesSystem.Gateway.API.Extensions;

public static class AppServiceExtensions
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();

        services.RegisterHttpClients();
        services.RegisterApplication(configuration);
        services.RegisterInfrastructure(configuration);

        return services;
    }


    public static IServiceCollection RegisterHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient(HttpNamedClient.CUSTOMER_SERVICE, (services, client) =>
        {
            var downstreamConfig = services.GetRequiredService<ServicesConfiguration>();
            var userProvider = services.GetRequiredService<ICurrentUserProvider>();
            var userContext = userProvider.GetCurrentUser();

            client.BaseAddress = new Uri(downstreamConfig.CustomerServiceBaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("KIND_OF_AUTHORIZATION", userContext.CustomerId.ToString());
        });

        services.AddHttpClient(HttpNamedClient.PRODUCT_SERVICE, (services, client) =>
        {
            using var scope = services.CreateScope();
            var downstreamConfig = scope.ServiceProvider.GetRequiredService<ServicesConfiguration>();
            var userProvider = scope.ServiceProvider.GetRequiredService<ICurrentUserProvider>();
            var userContext = userProvider.GetCurrentUser();

            client.BaseAddress = new Uri(downstreamConfig.ProductServiceBaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("KIND_OF_AUTHORIZATION", userContext.CustomerId.ToString());
        }); 
        
        services.AddHttpClient(HttpNamedClient.ACCOUNT_SERVICE, (services, client) =>
        {
            using var scope = services.CreateScope();
            var downstreamConfig = scope.ServiceProvider.GetRequiredService<ServicesConfiguration>();
            var userProvider = scope.ServiceProvider.GetRequiredService<ICurrentUserProvider>();
            var userContext = userProvider.GetCurrentUser();

            client.BaseAddress = new Uri(downstreamConfig.AccountServiceBaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("KIND_OF_AUTHORIZATION", userContext.CustomerId.ToString());
        });

        services.AddHttpClient(HttpNamedClient.LICENCE_SERVICE, (services, client) =>
        {
            using var scope = services.CreateScope();
            var downstreamConfig = scope.ServiceProvider.GetRequiredService<ServicesConfiguration>();
            var userProvider = scope.ServiceProvider.GetRequiredService<ICurrentUserProvider>();
            var userContext = userProvider.GetCurrentUser();

            client.BaseAddress = new Uri(downstreamConfig.LicenceServiceBaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("KIND_OF_AUTHORIZATION", userContext.CustomerId.ToString());
        });

        return services;
    }
}
