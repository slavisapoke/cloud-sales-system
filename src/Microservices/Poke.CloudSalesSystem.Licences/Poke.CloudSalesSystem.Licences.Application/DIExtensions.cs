using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Licences.Application.Handlers;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.CancelSubscription;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.ExtendLicence;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderLicences;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.UpdateLicenceQuantity;
using Poke.CloudSalesSystem.Licences.Application.Pipeline;

namespace Poke.CloudSalesSystem.Licences.Application;

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

        services.AddTransient<HandlerParams<CancelSubscriptionCommandHandler>>();
        services.AddTransient<HandlerParams<ExtendLicenceCommandHandler>>();
        services.AddTransient<HandlerParams<OrderLicencesCommandHandler>>();
        services.AddTransient<HandlerParams<UpdateLicenceQuantityCommandHandler>>();

        return services;
    }
}