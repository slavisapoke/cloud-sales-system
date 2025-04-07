using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Customers.Domain.Abstraction;
using Poke.CloudSalesSystem.Customers.Domain.Model;
using Poke.CloudSalesSystem.Customers.Domain.Repository;
using Poke.CloudSalesSystem.Customers.Infrastructure.Migrations;

namespace Infrastructure.Repository;

public class CustomersDbContext : DbContext, ICustomerDbContext
{
    private readonly TimeProvider _timeProvider;

    public DbSet<CustomerEntity> Customers { get; set; }

    public CustomersDbContext(DbContextOptions<CustomersDbContext> options,
        TimeProvider timeProvider)
        : base(options)
    {
        _timeProvider = timeProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomersDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        SeedCustomers.Seed(modelBuilder);
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
