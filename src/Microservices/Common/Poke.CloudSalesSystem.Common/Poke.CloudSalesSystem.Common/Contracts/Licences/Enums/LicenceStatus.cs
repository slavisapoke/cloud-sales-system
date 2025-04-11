using System.Text.Json.Serialization;

namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LicenceStatus
{
    Active = 1,
    Inactive,
    Expired,
    Suspended,
    //...//
    Cancelled = 100
}
