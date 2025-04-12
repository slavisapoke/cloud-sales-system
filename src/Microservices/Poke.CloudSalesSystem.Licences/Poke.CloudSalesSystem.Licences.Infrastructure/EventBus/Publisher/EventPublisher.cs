using MassTransit;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Licences.Application.Abstract;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.EventBus.Publisher
{
    public class EventPublisher(
        IPublishEndpoint publisher,
        ILogger<EventPublisher> logger) : IEventPublisher
    {
        public async Task Publish<T>(T @event)
        {
            try
            {
                if (@event is null)
                {
                    logger.LogWarning($"{nameof(EventPublisher)} recieved empty event of type: {typeof(T)}");
                    return;
                }

                await publisher.Publish(@event);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"[Publish] failed for {LogPlaceholders.EVENT}", @event);
            }
        }
    }
}
