using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Application.Model;

public class Subscription
{
    public required Guid Id { get; set; }
    public required Guid ExternalSubscriptionId { get; set; }
    public required Guid ServiceId { get; set; }
    public required int Quantity { get; set; } = 1;
    public required string ServiceName { get; set; }
    public SubscriptionStatus Status { get; set; }  
}
