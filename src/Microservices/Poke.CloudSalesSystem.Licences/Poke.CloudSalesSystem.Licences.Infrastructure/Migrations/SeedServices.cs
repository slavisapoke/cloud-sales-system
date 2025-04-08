using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Migrations;

public sealed class SeedServices
{
    public static Guid Service1_Id = Guid.Parse("d284eb26-9d42-4c16-89cb-ce75e0ab5afa");
    public static Guid Service2_Id = Guid.Parse("d384eb26-9d42-4c16-89cb-ce75e0ab5afa");

    public static Guid Provider = Guid.Parse("d484eb26-9d42-4c16-89cb-ce75e0ab5afa");

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceEntity>()
            .HasData(
                new ServiceEntity
                {
                    Id = Service1_Id,
                    Name = "Service 1",
                    Description = "Service 1 description...",
                    ProviderId = Provider
                },
                new ServiceEntity
                {
                    Id = Service2_Id,
                    Name = "Service 2",
                    Description = "Service 2 description...",
                    ProviderId = Provider
                }
            );
    }
}
