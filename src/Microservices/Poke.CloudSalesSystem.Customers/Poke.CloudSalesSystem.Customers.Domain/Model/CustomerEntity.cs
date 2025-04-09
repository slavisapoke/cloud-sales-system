using Poke.CloudSalesSystem.Common.Database.Abstraction;

namespace Poke.CloudSalesSystem.Customers.Domain.Model;

public class CustomerEntity : Entity<Guid>
{
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
