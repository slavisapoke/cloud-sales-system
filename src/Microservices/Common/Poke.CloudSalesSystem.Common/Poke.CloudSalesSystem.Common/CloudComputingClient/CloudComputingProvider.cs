using FluentResults;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;
using Poke.CloudSalesSystem.Common.CloudComputingClient.MockHttp;
using Poke.CloudSalesSystem.Common.Helpers;
using System.Net.Http.Json;

namespace Poke.CloudSalesSystem.Common.CloudComputingClient;

public class CloudComputingProvider : ICloudComputingProvider
{
    private readonly ILogger<CloudComputingProvider> _logger;
    private readonly CloudComputingConfiguration _ccConfig;

    public CloudComputingProvider(
        ILogger<CloudComputingProvider> logger,
        IOptions<CloudComputingConfiguration> ccOptions)
    {
        _logger = logger;
        _ccConfig = Preconditions.CheckNotNull(ccOptions.Value, nameof(ccOptions));
    }
    public async Task<IResult<IEnumerable<CloudComputingService>>> GetServices(CancellationToken cancellationToken)
    {
        using var client = new MockHttpClientBuilder(_ccConfig.ServiceUrl)
            .WithGetAllServices()
            .Build();

        var getServicesResponse = 
            await client.GetAsync($"{_ccConfig.ServiceUrl}/services", cancellationToken);

        if (!getServicesResponse.IsSuccessStatusCode)
        {
            var responseString = await getServicesResponse.Content.ReadAsStringAsync();
            return Result.Fail<IEnumerable<CloudComputingService>>(
                $"Status code: {getServicesResponse.StatusCode}, response content: {responseString}");
        }

        var result = await getServicesResponse.Content
            .ReadFromJsonAsync<IEnumerable<CloudComputingService>>(cancellationToken: cancellationToken)
            ?? [];

        return Result.Ok(result);
    }

    public async Task<IResult<OrderLicencesResponse>> OrderLicences(Guid accountId, Guid serviceId, int quantity,
        CancellationToken cancellationToken)
    {
        using var client = new MockHttpClientBuilder(_ccConfig.ServiceUrl)
            .WithOrderLicences(accountId, serviceId, quantity)
            .Build();

        var orderLicencesRequest =
            await client.GetAsync($"{_ccConfig.ServiceUrl}/order/{serviceId}/account/{accountId}/{quantity}",
                cancellationToken);

        if (!orderLicencesRequest.IsSuccessStatusCode)
        {
            var responseString = await orderLicencesRequest.Content.ReadAsStringAsync();
            return Result.Fail<OrderLicencesResponse>(
                $"Status code: {orderLicencesRequest.StatusCode}, response content: {responseString}");
        }

        var result = await orderLicencesRequest.Content
            .ReadFromJsonAsync<OrderLicencesResponse>(cancellationToken);

        return Result.Ok(result!);
    }

    public async Task<IResult<CancelSubscriptionResponse>> CancelSubscription(Guid serviceId, Guid accountId, CancellationToken cancellationToken)
    {
        using var client = new MockHttpClientBuilder(_ccConfig.ServiceUrl)
            .WithCancelSubscription(serviceId, accountId)
            .Build();

        var orderLicencesRequest =
            await client.GetAsync($"{_ccConfig.ServiceUrl}/services/{serviceId}/account/{accountId}/cancel",
                cancellationToken);

        if (!orderLicencesRequest.IsSuccessStatusCode)
        {
            var responseString = await orderLicencesRequest.Content.ReadAsStringAsync();
            return Result.Fail<CancelSubscriptionResponse>(
                $"Status code: {orderLicencesRequest.StatusCode}, response content: {responseString}");
        }

        var result = await orderLicencesRequest.Content
            .ReadFromJsonAsync<CancelSubscriptionResponse>(cancellationToken);

        return Result.Ok(result!);
    }
}
