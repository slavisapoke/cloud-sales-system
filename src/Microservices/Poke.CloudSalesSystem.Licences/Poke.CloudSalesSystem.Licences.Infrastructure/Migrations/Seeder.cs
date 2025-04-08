using Microsoft.EntityFrameworkCore;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Migrations;

public sealed class Seeder
{
    public static Guid Account1_Id = Guid.Parse("61db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account2_Id = Guid.Parse("62db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account3_Id = Guid.Parse("63db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account4_Id = Guid.Parse("64db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account5_Id = Guid.Parse("65db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account6_Id = Guid.Parse("66db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account7_Id = Guid.Parse("67db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account8_Id = Guid.Parse("68db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account9_Id = Guid.Parse("69db564e-5ef0-4614-9127-562a8b2856db");
    
    public static void Seed(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<ServiceEntity>()
        //   .HasData();
    }
}
