using Poke.CloudSalesSystem.Contracts.Events.Events;

namespace Poke.CloudSalesSystem.Licences.Application.Abstract;

public interface IEventPublisher 
{
    Task Publish<T>(T @event) where T : ICloudSalesEvent;
}
