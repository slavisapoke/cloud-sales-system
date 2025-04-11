using System.Text.Json.Serialization;

namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderLicencesStatus
{
    NewSubscription,
    LicencesAquired,
    LicencesAquiredPartially,
    OrderFailed
}
