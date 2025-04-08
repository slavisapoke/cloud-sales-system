using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Accounts.Domain.Model;

namespace Poke.CloudSalesSystem.Accounts.Infrastructure.Migrations;

public sealed class SeedAccounts
{
    //should be sequential guid, this is just initial data
    //migration added for adding plugin for sequential uuid generation before insert
    public static Guid Customer1_Id = Guid.Parse("43c8a677-2345-4ba2-993e-46668d76ab6e");
    public static Guid Customer2_Id = Guid.Parse("86ddb9e8-3c41-4774-aace-4289afb73eeb");
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
        modelBuilder.Entity<AccountEntity>()
           .HasData(
                new AccountEntity { CustomerId = Customer1_Id, Id = Account1_Id, Name = "account_uno@zika.com", Phone = "123456" },
                new AccountEntity { CustomerId = Customer1_Id, Id = Account2_Id, Name = "account_due@zika.com", Phone = "223332" },
                new AccountEntity { CustomerId = Customer1_Id, Id = Account3_Id, Name = "account_tre@zika.com", Phone = "234254" },
                new AccountEntity { CustomerId = Customer1_Id, Id = Account4_Id, Name = "account_quattro@zika.com", Phone = "6455645645" },
                new AccountEntity { CustomerId = Customer1_Id, Id = Account5_Id, Name = "account_cinque@zika.com", Phone = "2342333" },
                new AccountEntity { CustomerId = Customer2_Id, Id = Account6_Id, Name = "account_sei@zika.com", Phone = "2233545332" },
                new AccountEntity { CustomerId = Customer2_Id, Id = Account7_Id, Name = "account_sette@zika.com", Phone = "23423434" },
                new AccountEntity { CustomerId = Customer2_Id, Id = Account8_Id, Name = "account_otto@zika.com", Phone = "4566655" },
                new AccountEntity { CustomerId = Customer2_Id, Id = Account9_Id, Name = "account_nove@zika.com", Phone = "2342342" }
            );
    }
}
