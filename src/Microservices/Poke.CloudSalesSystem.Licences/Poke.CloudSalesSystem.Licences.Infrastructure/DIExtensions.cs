using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Common.CloudComputingClient;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;
using Poke.CloudSalesSystem.Licences.Domain.Repository;
using Poke.CloudSalesSystem.Common.MessageBus.RabbitMQ.Extensions;
using Poke.CloudSalesSystem.Licences.Infrastructure.EventBus.Consumers;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Common.MessageBus.RabbitMQ;
using Poke.CloudSalesSystem.Licences.Application.Abstract;
using Poke.CloudSalesSystem.Licences.Infrastructure.EventBus.Publisher;

namespace Poke.CloudSalesSystem.Licences.Infrastructure;

public static class DIExtensions
{
    public static IServiceCollection RegisterInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        //.net8 preview contains TimeProvider.System
        services.AddTransient<TimeProvider, CustomTimeProvider>();
        services.AddTransient<ICloudComputingProvider, CloudComputingProvider>();
        services.AddTransient<IEventPublisher, EventPublisher>();

        var connectionString =
           configuration.GetConnectionString("Postgres") ??
           throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<LicencesDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseCamelCaseNamingConvention();
        });
        services.AddScoped<ILicencesDbContext>(provider => provider.GetRequiredService<LicencesDbContext>());

        var rabbitConfig = configuration.GetSection(nameof(RabbitMQConfiguration))
            .Get<RabbitMQConfiguration>();

        Preconditions.CheckNotNull(rabbitConfig, nameof(rabbitConfig));

        services.RegisterMessageBrokerWithOutbox<LicencesDbContext, AccountDeletedConsumer>(
            "licence", rabbitConfig!);

        return services;
    }
}
