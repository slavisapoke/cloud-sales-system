using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Accounts.Domain.Abstraction;
using Poke.CloudSalesSystem.Accounts.Domain.Model;
using Poke.CloudSalesSystem.Accounts.Domain.Repository;
using Poke.CloudSalesSystem.Accounts.Infrastructure.Migrations;

namespace Infrastructure.Repository;

public class AccountsDbContext : DbContext, IAccountsDbContext
{
    private readonly TimeProvider _timeProvider;

    public DbSet<AccountEntity> Accounts { get; set; }

    public AccountsDbContext(DbContextOptions<AccountsDbContext> options,
        TimeProvider timeProvider)
        : base(options)
    {
        _timeProvider = timeProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        SeedAccounts.Seed(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestamps()
    {
        var utcNow = _timeProvider.GetUtcNow();

        foreach(var entity in ChangeTracker.Entries()
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
