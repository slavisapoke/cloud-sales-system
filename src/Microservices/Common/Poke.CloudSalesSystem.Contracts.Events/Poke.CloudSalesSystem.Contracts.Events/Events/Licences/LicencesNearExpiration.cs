using Poke.CloudSalesSystem.Common.Contracts.Licences;

namespace Poke.CloudSalesSystem.Contracts.Events.Events.Licences;

public record LicencesNearExpiration(IReadOnlyCollection<Licence> licences) : ICloudSalesEvent;