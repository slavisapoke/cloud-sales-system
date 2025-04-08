﻿namespace Poke.CloudSalesSystem.Accounts.Domain.Abstraction;

public interface IEntityWithTimestamp
{
    void SetCreatedOn(DateTimeOffset createdOn);
    void SetModifiedOn(DateTimeOffset modifiedOn);
}
