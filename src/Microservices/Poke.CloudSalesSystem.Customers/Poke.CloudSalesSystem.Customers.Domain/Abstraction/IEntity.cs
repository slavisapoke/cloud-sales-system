namespace Poke.CloudSalesSystem.Customers.Domain.Abstraction;

public interface IEntity<EntityId>
{
    EntityId Id { get; }
}
