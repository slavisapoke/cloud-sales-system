namespace Poke.CloudSalesSystem.Contracts.Events.Events.System;

public class ActionFailedEvent
{
    //some codes that event consumers can understand
    public int Code { get; private set; }
    public string? Reason { get; private set; }

    public static ActionFailedEvent<TAction> Create<TAction>(int code, TAction payload, string reason) =>
        new ActionFailedEvent<TAction>
        {
            Code = code,
            Payload = payload,
            Reason = reason
        };
}

public class ActionFailedEvent<T> : ActionFailedEvent, ICloudSalesEvent
{
    public T? Payload { get; init; }
}