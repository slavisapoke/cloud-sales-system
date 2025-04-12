namespace Poke.CloudSalesSystem.Contracts.Events.Events.System
{
    public record InconsistentEntityState<T>(string Reason, T context);
}
