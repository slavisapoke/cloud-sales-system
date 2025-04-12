using Poke.CloudSalesSystem.Common.Contracts.Licences;

namespace Poke.CloudSalesSystem.Contracts.Events.Events.Licences;

public record LicencesCanceled(IReadOnlyCollection<Licence> licences);