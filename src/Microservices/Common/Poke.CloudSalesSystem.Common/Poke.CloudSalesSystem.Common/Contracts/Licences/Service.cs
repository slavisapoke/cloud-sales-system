namespace Poke.CloudSalesSystem.Common.Contracts.Licences;

public class Service
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ProviderId { get; set; }
}
