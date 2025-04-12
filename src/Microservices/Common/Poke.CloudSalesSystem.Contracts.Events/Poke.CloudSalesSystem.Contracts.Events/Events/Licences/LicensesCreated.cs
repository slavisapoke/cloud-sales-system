using Poke.CloudSalesSystem.Common.Contracts.Licences;

namespace Poke.CloudSalesSystem.Contracts.Events.Events.Licences;

public record LicensesCreated(IReadOnlyCollection<Licence> licences);