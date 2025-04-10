namespace Poke.CloudSalesSystem.Common.Contracts.Customers;

public class Customer
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
