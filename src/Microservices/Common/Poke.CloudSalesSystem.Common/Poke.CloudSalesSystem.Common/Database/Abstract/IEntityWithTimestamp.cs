namespace Poke.CloudSalesSystem.Common.Database.Abstraction;

public interface IEntityWithTimestamp
{
    void SetCreatedOn(DateTimeOffset createdOn);
    void SetModifiedOn(DateTimeOffset modifiedOn);
}
