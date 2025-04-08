using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Common.Database.Abstraction;

namespace Poke.CloudSalesSystem.Common.Database;

/// <summary>
/// Represents base class for EFCore DbContext. Handles the logic of updating timestamp fields 
/// </summary>
public class BaseDbContext : DbContext
{
    private readonly TimeProvider _timeProvider;

    public BaseDbContext(DbContextOptions options,
        TimeProvider timeProvider)
        : base(options)
    {
        _timeProvider = timeProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestamps()
    {
        var utcNow = _timeProvider.GetUtcNow();

        foreach (var entity in ChangeTracker.Entries()
            .Where(e => e.Entity is IEntityWithTimestamp && e.State is EntityState.Added or EntityState.Modified))
        {
            if (entity.State is EntityState.Added)
            {
                var dbEntity = entity.Entity;
                ((IEntityWithTimestamp)dbEntity).SetCreatedOn(utcNow);
            }
            else //modified
            {
                ((IEntityWithTimestamp)entity.Entity).SetModifiedOn(utcNow);
            }
        }
    }
}
