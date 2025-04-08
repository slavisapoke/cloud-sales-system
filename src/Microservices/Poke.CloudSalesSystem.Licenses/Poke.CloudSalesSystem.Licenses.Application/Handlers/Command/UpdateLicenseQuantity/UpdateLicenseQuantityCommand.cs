namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.UpdateLicenseQuantity;

public record UpdateLicenseQuantityCommand(Guid AccountId, Guid SubscriptionId, int NewQuantity)
    : IRequestWithFluentResult<UpdateLicenseQuantityCommandResponse>;

