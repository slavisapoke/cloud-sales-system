using Poke.CloudSalesSystem.Common.Contracts;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Request;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Response;

namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

public interface ILicenceService
{
    Task<ApiResponse<CancelSubscriptionResponse>?> CancelSubscription(
        CancelSubscriptionRequest request, CancellationToken cancellationToken);

    Task<ApiResponse<ExtendLicenceResponse>?> ExtendLicense(
        ExtendLicenceRequest request, CancellationToken cancellationToken);

    Task<ApiResponse<OrderLicencesResponse>?> OrderLicenses(
        OrderLicencesRequest request, CancellationToken cancellationToken);

    Task<ApiResponse<UpdateLicenceQuantityResponse>?> UpdateLicenseQuantity(
        UpdateLicenceQuantityRequest request, CancellationToken cancellationToken);

    Task<ApiResponse<GetAccountLicencesResponse>?> GetAccountLicenses(
        Guid accountId, CancellationToken cancellationToken);
}
