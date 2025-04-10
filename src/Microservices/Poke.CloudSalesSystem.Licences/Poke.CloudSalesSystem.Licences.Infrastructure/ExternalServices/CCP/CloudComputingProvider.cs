using FluentResults;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Licences.Application.Abstraction;
using Poke.CloudSalesSystem.Licences.Application.Configuration;
using Poke.CloudSalesSystem.Licences.Application.Model.CloudComputing;
using Poke.CloudSalesSystem.Licences.Infrastructure.ExternalServices.CCP.MockHttp;
using System.Net.Http.Json;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.ExternalServices.CCP;

public class CloudComputingProvider : ICloudComputingProvider
{
    private readonly ILogger<CloudComputingProvider> _logger;
    private readonly CloudComputingConfiguration _ccOptions;

    public CloudComputingProvider(
        ILogger<CloudComputingProvider> logger,
        IOptions<CloudComputingConfiguration> ccOptions)
    {
        _logger = logger;
        _ccOptions = Preconditions.CheckNotNull(ccOptions.Value, nameof(ccOptions));
    }
    public async Task<IResult<IEnumerable<CloudComputingService>>> GetServices(CancellationToken cancellationToken)
    {
        using var client = new MockHttpClientBuilder(_ccOptions.ServiceUrl)
            .WithGetAllServices()
            .Build();

        var getServicesResponse = 
            await client.GetAsync($"{_ccOptions.ServiceUrl}/services", cancellationToken);

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
        using var client = new MockHttpClientBuilder(_ccOptions.ServiceUrl)
            .WithOrderLicences(accountId, serviceId, quantity)
            .Build();

        var orderLicencesRequest =
            await client.GetAsync($"{_ccOptions.ServiceUrl}/services/${serviceId}/account/${accountId}/{quantity}",
                cancellationToken);

        if (!orderLicencesRequest.IsSuccessStatusCode)
        {
            var responseString = await orderLicencesRequest.Content.ReadAsStringAsync();
            return Result.Fail<OrderLicencesResponse>(
                $"Status code: {orderLicencesRequest.StatusCode}, response content: {responseString}");
        }

        var result = await orderLicencesRequest.Content
            .ReadFromJsonAsync<OrderLicencesResponse>(cancellationToken: cancellationToken);

        return Result.Ok(result!);
    }
}
