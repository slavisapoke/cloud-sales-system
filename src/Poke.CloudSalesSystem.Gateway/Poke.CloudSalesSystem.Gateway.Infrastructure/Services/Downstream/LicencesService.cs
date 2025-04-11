
using Poke.CloudSalesSystem.Common.Contracts;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Request;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Response;

namespace Poke.CloudSalesSystem.Gateway.Infrastructure.Services.Downstream;

public class LicencesService : ILicenceService
{
    private readonly HttpClient client;

    public LicencesService(IHttpClientFactory httpFactory)
    {
        client = httpFactory.CreateClient(HttpNamedClient.LICENCE_SERVICE);
    }

    public async Task<ApiResponse<CancelSubscriptionResponse>?> CancelSubscription(
        CancelSubscriptionRequest request, CancellationToken cancellationToken)
    {
        return await client.PostAsyncThrowable<ApiResponse<CancelSubscriptionResponse>, CancelSubscriptionRequest>(
            "licences/subscription/cancel", request, cancellationToken);
    }

    public async Task<ApiResponse<ExtendLicenceResponse>?> ExtendLicense(
        ExtendLicenceRequest request, CancellationToken cancellationToken)
    {
        return await client.PostAsyncThrowable<ApiResponse<ExtendLicenceResponse>, ExtendLicenceRequest>(
            "licences/extend", request, cancellationToken);
    }

    public async Task<ApiResponse<GetAccountLicencesResponse>?> GetAccountLicenses(Guid accountId, CancellationToken cancellationToken)
    {
        return await client.GetAsyncThrowable<ApiResponse<GetAccountLicencesResponse>>(
            $"licences/{accountId}", cancellationToken);
    }

    public async  Task<ApiResponse<OrderLicencesResponse>?> OrderLicenses(
        OrderLicencesRequest request, CancellationToken cancellationToken)
    {
        return await client.PostAsyncThrowable<ApiResponse<OrderLicencesResponse>, OrderLicencesRequest>(
            "licences/order", request, cancellationToken);
    }

    public async Task<ApiResponse<UpdateLicenceQuantityResponse>?> UpdateLicenseQuantity(
        UpdateLicenceQuantityRequest request, CancellationToken cancellationToken)
    {
        return await client.PostAsyncThrowable< ApiResponse<UpdateLicenceQuantityResponse>, UpdateLicenceQuantityRequest>(
            "licences/subscription/update", request, cancellationToken);
    }
}
