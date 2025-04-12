using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Common.MessageBus.RabbitMQ.Filters;

namespace Poke.CloudSalesSystem.Common.MessageBus.RabbitMQ.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Creates simple message broker with supporting outbox db
        /// </summary>
        /// <typeparam name="TOutboxDbContext"></typeparam>
        /// <typeparam name="TTopConsumer"></typeparam>
        /// <param name="services"></param>
        /// <param name="namePrefix"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterMessageBrokerWithOutbox<TOutboxDbContext, TTopConsumer>(this IServiceCollection services,
            string namePrefix, RabbitMQConfiguration config) where TOutboxDbContext : DbContext
        {
            Preconditions.CheckNotNull(config, nameof(config));
            Preconditions.CheckNotNull(config.Host, nameof(config.Host));
            Preconditions.CheckGreaterThanZero(config.Port);

            services.AddMassTransit(ctx =>
            {
                ctx.AddEntityFrameworkOutbox<TOutboxDbContext>(o =>
                {
                    o.QueryDelay = TimeSpan.FromSeconds(10);
                    o.UsePostgres();
                    o.UseBusOutbox();
                });

                ctx.AddConsumersFromNamespaceContaining<TTopConsumer>();
                ctx.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(namePrefix, false));
                ctx.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(config.Host, (ushort)config.Port, "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.UsePublishFilter(typeof(LoggingPublishFilter<>), context);
                    cfg.UseConsumeFilter(typeof(LoggingConsumeFilter<>), context);
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }

        /// <summary>
        /// Registers simple message broker with consumers
        /// </summary>
        /// <typeparam name="TTopConsumer">Register consumers from the assembly of TConsumerExample class</typeparam>
        /// <param name="services"></param>
        /// <param name="namePrefix"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterMessageBroker<TTopConsumer>(this IServiceCollection services, 
            string namePrefix, RabbitMQConfiguration config) 
        {
            Preconditions.CheckNotNull(config, nameof(config));
            Preconditions.CheckNotNull(config.Host, nameof(config.Host));
            Preconditions.CheckGreaterThanZero(config.Port);

            services.AddMassTransit(ctx =>
            {
                ctx.AddConsumersFromNamespaceContaining<TTopConsumer>();
                ctx.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(namePrefix, false));
                ctx.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(config.Host, (ushort)config.Port, "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.UsePublishFilter(typeof(LoggingPublishFilter<>), context);
                    cfg.UseConsumeFilter(typeof(LoggingConsumeFilter<>), context);
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
