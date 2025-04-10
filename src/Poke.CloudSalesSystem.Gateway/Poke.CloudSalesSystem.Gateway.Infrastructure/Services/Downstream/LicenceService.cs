
using Poke.CloudSalesSystem.Common.Contracts.Licences.Request;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Response;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

namespace Poke.CloudSalesSystem.Gateway.Infrastructure.Services.Downstream;

public class LicenceService : ILicenceService
{
    public Task<CancelSubscriptionResponse> CancelSubscription(CancelSubscriptionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ExtendLicenceResponse> ExtendLicense(ExtendLicenceRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<GetAccountLicencesResponse> GetAccountLicenses(Guid accountId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<OrderLicencesResponse> OrderLicenses(OrderLicencesRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateLicenceQuantityResponse> UpdateLicenseQuantity(UpdateLicenceQuantityRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
