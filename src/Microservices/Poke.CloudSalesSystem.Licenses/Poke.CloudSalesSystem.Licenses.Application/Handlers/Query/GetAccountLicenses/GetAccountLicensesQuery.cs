namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Query.GetAccountLicenses;

public record GetAccountLicensesQuery(Guid AccountId) : 
    IRequestWithFluentResult<GetAccountLicensesQueryResponse>;

