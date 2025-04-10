namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.CancelSubscription
{
    public record CancelSubscriptionCommandResponse(
        Guid SubscriptionId,
        bool IsSuccess,
        string? Message);
}