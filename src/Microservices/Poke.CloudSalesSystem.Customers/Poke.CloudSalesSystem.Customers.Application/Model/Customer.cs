using System.Xml.Linq;

namespace Poke.CloudSalesSystem.Customers.Application.Model;
public class Customer
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
