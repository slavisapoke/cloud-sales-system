namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.UpdateLicenceQuantity
{
    public record UpdateLicenceQuantityCommandResponse(
        Guid SubscriptionId,
        bool IsSuccess,
        string? Message);
}