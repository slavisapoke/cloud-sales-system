namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.CancelSubscription
{
    public record CancelSubscriptionCommandResponse(
        Guid subscriptionId,
        IEnumerable<Guid> revokedLicences, 
        string Message);
}