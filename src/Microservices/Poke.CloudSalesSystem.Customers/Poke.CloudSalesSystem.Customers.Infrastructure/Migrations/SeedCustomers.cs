using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Customers.Domain.Model;

namespace Poke.CloudSalesSystem.Customers.Infrastructure.Migrations;

public sealed class SeedCustomers
{
    //should be sequential guid, this is just initial data
    //migration added for adding plugin for sequential uuid generation before insert
    public static Guid Customer1_Id = Guid.Parse("43c8a677-2345-4ba2-993e-46668d76ab6e");
    public static Guid Customer2_Id = Guid.Parse("86ddb9e8-3c41-4774-aace-4289afb73eeb");
    
    public static void Seed(ModelBuilder modelBuilder)
    {
        CustomerEntity zika = new() { Id = Customer1_Id, Name = "Zika Pavlovic" };
        CustomerEntity milan = new() { Id = Customer2_Id, Name = "Milan Todorovic" };

        modelBuilder.Entity<CustomerEntity>()
           .HasData(zika, milan);
    }
}
