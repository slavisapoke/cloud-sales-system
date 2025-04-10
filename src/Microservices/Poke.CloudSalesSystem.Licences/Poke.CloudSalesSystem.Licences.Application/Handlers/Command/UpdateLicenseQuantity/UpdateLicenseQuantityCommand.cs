namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.UpdateLicenceQuantity;

public record UpdateLicenceQuantityCommand(Guid ServiceId, Guid AccountId, int NewQuantity)
    : IRequestWithFluentResult<UpdateLicenceQuantityCommandResponse>;

