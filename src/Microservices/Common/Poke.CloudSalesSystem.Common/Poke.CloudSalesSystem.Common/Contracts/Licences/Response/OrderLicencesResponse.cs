
using Poke.CloudSalesSystem.Common.Contracts.Licences.Enums;

namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Response;

public record OrderLicencesResponse(
    Guid AccountId,
    Guid SubscriptionId,
    Guid ServiceId,
    List<Licence> Licences,
    OrderLicencesStatus Status,
    string? Reason);