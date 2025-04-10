namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Response;

public class GetAccountLicencesResponse
{
    public Guid AccountId { get; set; }
    public List<Licence> Licences { get; set; } = [];
    public List<Subscription> Subscriptions { get; set; } = [];
}