namespace Poke.CloudSalesSystem.Licences.Application.Model;

public class Account
{
    public required Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
