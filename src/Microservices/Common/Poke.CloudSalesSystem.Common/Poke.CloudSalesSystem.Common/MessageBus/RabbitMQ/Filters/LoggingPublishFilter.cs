using MassTransit;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;

namespace Poke.CloudSalesSystem.Common.MessageBus.RabbitMQ.Filters;

/// <summary>
/// Just logging what publisher sends
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="logger"></param>
public class LoggingPublishFilter<T> (ILogger<LoggingPublishFilter<T>> logger)
    : IFilter<PublishContext<T>> where T : class
{
    public async Task Send(PublishContext<T> context, IPipe<PublishContext<T>> next)
    {
        logger.LogInformation($"[Publish] {typeof(T).Name}: {LogPlaceholders.MESSAGE}", context.Message);
        await next.Send(context);
    }

    public void Probe(ProbeContext context)
    {
    }
}
