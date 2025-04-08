using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Licenses.Domain.Model;
using Poke.CloudSalesSystem.Licenses.Domain.Repository;
using Poke.CloudSalesSystem.Licenses.Infrastructure.Migrations;
using Poke.CloudSalesSystem.Common.Database;

namespace Infrastructure.Repository;
 

public class LicensesDbContext : BaseDbContext, ILicensesDbContext
{
    public DbSet<ServiceEntity> Services { get; set; }

    public LicensesDbContext(DbContextOptions<LicensesDbContext> options,
        TimeProvider timeProvider)
        : base(options, timeProvider)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LicensesDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        Seeder.Seed(modelBuilder);
    }
}
