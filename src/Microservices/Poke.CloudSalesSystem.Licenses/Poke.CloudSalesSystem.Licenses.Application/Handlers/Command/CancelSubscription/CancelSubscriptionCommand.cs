namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.CancelSubscription;

public record CancelSubscriptionCommand 
    (Guid AccountId, Guid SubscriptionId)
    : IRequestWithFluentResult<CancelSubscriptionCommandResponse>;
