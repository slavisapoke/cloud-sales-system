namespace Poke.CloudSalesSystem.Common.Cache;

public class CachingConfiguration
{
    public required string ServiceName { get; set; }   
    public required int MemoryCacheGlobalDurationInSeconds { get; set; }
    public required string InstanceName { get; set; }
}
