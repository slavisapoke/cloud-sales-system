namespace Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;

public class CloudComputingService
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ProviderId { get; set; }
}
