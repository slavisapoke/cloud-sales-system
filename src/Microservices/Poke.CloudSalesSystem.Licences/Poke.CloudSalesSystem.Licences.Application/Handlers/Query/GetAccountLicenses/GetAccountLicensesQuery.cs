namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Query.GetAccountLicences;

public record GetAccountLicencesQuery(Guid AccountId) : 
    IRequestWithFluentResult<GetAccountLicencesQueryResponse>;

