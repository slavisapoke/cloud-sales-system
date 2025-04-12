using MassTransit;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Contracts.Events.Events;
using Poke.CloudSalesSystem.Licences.Application.Abstract;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.EventBus.Publisher
{
    /// <summary>
    /// Event publishing to MassTransit
    /// </summary>
    /// <param name="publisher"></param>
    /// <param name="logger"></param>
    public class EventPublisher(
        IPublishEndpoint publisher,
        ILogger<EventPublisher> logger) : IEventPublisher
    {
        /// <summary>
        /// Safe event publishing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        /// <returns></returns>
        public async Task Publish<T>(T @event)
            where T : ICloudSalesEvent
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
