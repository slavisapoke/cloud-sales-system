using Poke.CloudSalesSystem.Common.Contracts;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Request;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Response;

namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

/// <summary>
/// Licence service
/// </summary>
public interface ILicenceService
{
    /// <summary>
    /// Cancel given subscription
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ApiResponse<CancelSubscriptionResponse>?> CancelSubscription(
        CancelSubscriptionRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Extends given licence
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ApiResponse<ExtendLicenceResponse>?> ExtendLicense(
        ExtendLicenceRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Order new licences for the given service and account
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ApiResponse<OrderLicencesResponse>?> OrderLicenses(
        OrderLicencesRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Update licence quantity for the given service and account
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ApiResponse<UpdateLicenceQuantityResponse>?> UpdateLicenseQuantity(
        UpdateLicenceQuantityRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Get all licences for the given account
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ApiResponse<GetAccountLicencesResponse>?> GetAccountLicenses(
        Guid accountId, CancellationToken cancellationToken);
}
