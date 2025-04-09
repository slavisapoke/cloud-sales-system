using Poke.CloudSalesSystem.Licences.Application.Model;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Query.GetAccountLicences
{
    public class GetAccountLicencesQueryResponse
    {
        public Guid AccountId { get; set; }
        public List<Licence> Licences { get; set; } = [];
    }
}