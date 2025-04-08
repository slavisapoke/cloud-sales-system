namespace Poke.CloudSalesSystem.Licences.Application.Model;

public class Subscription
{
    public required Guid Id { get; set; }
    public required Guid ExternalSubscriptionId { get; set; }
    public required Guid Service { get; set; }
    public required int Quantity { get; set; } = 1;
    public int Status { get; set; }     //active, blocked... who knows what
}
