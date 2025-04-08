using Microsoft.EntityFrameworkCore;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Migrations;

public sealed class Seeder
{ 
    public static void Seed(ModelBuilder modelBuilder)
    {
        SeedServices.Seed(modelBuilder);
        SeedSubscriptions.Seed(modelBuilder);
        SeedLicences.Seed(modelBuilder);
    }
}
