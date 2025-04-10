using Poke.CloudSalesSystem.Common.Contracts.Licences.Request;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Response;

namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

public interface ILicenceService
{
    Task<CancelSubscriptionResponse> CancelSubscription(
        CancelSubscriptionRequest request, CancellationToken cancellationToken);

    Task<ExtendLicenceResponse> ExtendLicense(
        ExtendLicenceRequest request, CancellationToken cancellationToken);

    Task<OrderLicencesResponse> OrderLicenses(
        OrderLicencesRequest request, CancellationToken cancellationToken);

    Task<UpdateLicenceQuantityResponse> UpdateLicenseQuantity(
        UpdateLicenceQuantityRequest request, CancellationToken cancellationToken);

    Task<GetAccountLicencesResponse> GetAccountLicenses(
        Guid accountId, CancellationToken cancellationToken);
}
