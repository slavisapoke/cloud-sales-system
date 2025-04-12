using MassTransit;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;

namespace Poke.CloudSalesSystem.Common.MessageBus.RabbitMQ.Filters;

/// <summary>
/// Just logging what consumers recieve
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="logger"></param>
public class LoggingConsumeFilter<T> (ILogger<LoggingConsumeFilter<T>> logger)
    : IFilter<ConsumeContext<T>> where T : class
{ 

    public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
    {
        logger.LogInformation($"[Consume] {typeof(T).Name}: {LogPlaceholders.MESSAGE}", context.Message);
        await next.Send(context);
    }

    public void Probe(ProbeContext context) { }
}
