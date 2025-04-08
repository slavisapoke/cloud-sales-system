using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Licences.Domain.Model;
using Poke.CloudSalesSystem.Licences.Domain.Repository;
using Poke.CloudSalesSystem.Licences.Infrastructure.Migrations;
using Poke.CloudSalesSystem.Common.Database;

namespace Infrastructure.Repository;
 
public class LicencesDbContext : BaseDbContext, ILicencesDbContext
{
    public DbSet<ServiceEntity> Services { get; set; }

    public LicencesDbContext(DbContextOptions<LicencesDbContext> options,
        TimeProvider timeProvider)
        : base(options, timeProvider)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LicencesDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        Seeder.Seed(modelBuilder);
    }
}
