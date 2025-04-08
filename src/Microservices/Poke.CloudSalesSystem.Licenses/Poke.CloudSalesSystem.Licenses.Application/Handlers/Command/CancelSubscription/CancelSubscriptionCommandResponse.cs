namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.CancelSubscription
{
    public record CancelSubscriptionCommandResponse(
        Guid subscriptionId,
        IEnumerable<Guid> revokedLicenses, 
        string Message);
}