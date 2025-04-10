using FluentResults;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;

namespace Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;

public interface ICloudComputingProvider
{
    Task<IResult<IEnumerable<CloudComputingService>>> GetServices(
        CancellationToken cancellationToken);

    Task<IResult<OrderLicencesResponse>> OrderLicences(Guid accountId, Guid serviceId, int quantity, 
        CancellationToken cancellationToken);

    Task<IResult<CancelSubscriptionResponse>> CancelSubscription(Guid serviceId, Guid accountId,
        CancellationToken cancellationToken);
}
