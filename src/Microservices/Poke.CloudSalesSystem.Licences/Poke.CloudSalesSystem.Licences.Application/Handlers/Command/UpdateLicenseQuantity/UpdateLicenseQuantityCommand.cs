namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.UpdateLicenceQuantity;

public record UpdateLicenceQuantityCommand(Guid AccountId, Guid SubscriptionId, int NewQuantity)
    : IRequestWithFluentResult<UpdateLicenceQuantityCommandResponse>;

