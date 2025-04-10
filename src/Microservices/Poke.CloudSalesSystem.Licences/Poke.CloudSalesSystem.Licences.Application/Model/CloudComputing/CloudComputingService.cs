namespace Poke.CloudSalesSystem.Licences.Application.Model.CloudComputing;

public class CloudComputingService
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ProviderId { get; set; }
}
