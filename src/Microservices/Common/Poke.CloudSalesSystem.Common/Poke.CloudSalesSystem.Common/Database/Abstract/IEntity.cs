namespace Poke.CloudSalesSystem.Common.Database.Abstraction;

public interface IEntity<EntityId>
{
    EntityId Id { get; }
}
