namespace Poke.CloudSalesSystem.Accounts.Domain.Abstraction;

public interface IEntity<EntityId>
{
    EntityId Id { get; }
}
