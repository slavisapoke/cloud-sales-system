using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Common.Database;
using Poke.CloudSalesSystem.Customers.Domain.Model;
using Poke.CloudSalesSystem.Customers.Domain.Repository;
using Poke.CloudSalesSystem.Customers.Infrastructure.Migrations;

namespace Infrastructure.Repository;

public class CustomersDbContext : BaseDbContext, ICustomerDbContext
{
    public DbSet<CustomerEntity> Customers { get; set; }

    public CustomersDbContext(DbContextOptions<CustomersDbContext> options,
        TimeProvider timeProvider)
        : base(options, timeProvider)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomersDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        SeedCustomers.Seed(modelBuilder);
    }
}
