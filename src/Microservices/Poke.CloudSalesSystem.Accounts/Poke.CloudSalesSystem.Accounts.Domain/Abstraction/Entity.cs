namespace Poke.CloudSalesSystem.Accounts.Domain.Abstraction;

#pragma warning disable CS8618 
public abstract class Entity<EntityId> : IEntityWithTimestamp, IEntity<EntityId>
{
    public EntityId Id { get; set; }
    public DateTimeOffset CreatedOn { get; private set; }
    public DateTimeOffset? ModifiedOn { get; private set; }

    public void SetCreatedOn(DateTimeOffset createdOn) => CreatedOn = createdOn;

    public void SetModifiedOn(DateTimeOffset modifiedOn) => ModifiedOn = modifiedOn;
}
#pragma warning restore CS8618