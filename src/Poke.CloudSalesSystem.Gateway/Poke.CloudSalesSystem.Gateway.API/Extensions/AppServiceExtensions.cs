using Poke.CloudSalesSystem.Gateway.API.Authorization;
using Poke.CloudSalesSystem.Gateway.API.Handlers;
using Poke.CloudSalesSystem.Gateway.Application;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;
using Poke.CloudSalesSystem.Gateway.Application.Configuration;
using Poke.CloudSalesSystem.Gateway.Application.Constants;
using Poke.CloudSalesSystem.Gateway.Infrastructure;
using Polly;
using Polly.Extensions.Http;

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

    /// <summary>
    /// Registering downstream service clients
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterHttpClients(this IServiceCollection services)
    {
        services.AddTransient<AuthorizationForwarderHandler>();

        services.AddHttpClient(HttpNamedClient.CUSTOMER_SERVICE, (services, client) =>
            {
                using var scope = services.CreateScope();
                var downstreamConfig = scope.ServiceProvider.GetRequiredService<ServicesConfiguration>();

                client.BaseAddress = new Uri(downstreamConfig.CustomerServiceBaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddHttpMessageHandler<AuthorizationForwarderHandler>()
            .AddPolicyHandler(GetRetryPolicy());

        services.AddHttpClient(HttpNamedClient.PRODUCT_SERVICE, (services, client) =>
            {
                using var scope = services.CreateScope();
                var downstreamConfig = scope.ServiceProvider.GetRequiredService<ServicesConfiguration>();

                client.BaseAddress = new Uri(downstreamConfig.ProductServiceBaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddHttpMessageHandler<AuthorizationForwarderHandler>()
            .AddPolicyHandler(GetRetryPolicy());

        services.AddHttpClient(HttpNamedClient.ACCOUNT_SERVICE, (services, client) =>
            {
                using var scope = services.CreateScope();
                var downstreamConfig = scope.ServiceProvider.GetRequiredService<ServicesConfiguration>();

                client.BaseAddress = new Uri(downstreamConfig.AccountServiceBaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddHttpMessageHandler<AuthorizationForwarderHandler>()
            .AddPolicyHandler(GetRetryPolicy());

        services.AddHttpClient(HttpNamedClient.LICENCE_SERVICE, (services, client) =>
            {
                using var scope = services.CreateScope();
                var downstreamConfig = scope.ServiceProvider.GetRequiredService<ServicesConfiguration>();

                client.BaseAddress = new Uri(downstreamConfig.LicenceServiceBaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddHttpMessageHandler<AuthorizationForwarderHandler>()
            .AddPolicyHandler(GetRetryPolicy()); 

        return services;
    }

    static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(1, attempt)), // Exponential backoff
                onRetry: (outcome, timespan, retryAttempt, context) =>
                {
                    Console.WriteLine($"Retrying... attempt {retryAttempt}");
                });
    }

}
