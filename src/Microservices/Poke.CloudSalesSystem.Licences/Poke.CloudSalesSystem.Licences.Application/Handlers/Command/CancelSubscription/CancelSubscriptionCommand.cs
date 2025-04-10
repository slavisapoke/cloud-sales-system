namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.CancelSubscription;

public record CancelSubscriptionCommand 
    (Guid AccountId, Guid ServiceId)
    : IRequestWithFluentResult<CancelSubscriptionCommandResponse>;
