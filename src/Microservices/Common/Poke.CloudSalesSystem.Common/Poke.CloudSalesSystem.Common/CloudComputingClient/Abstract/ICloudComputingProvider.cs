using FluentResults;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;

namespace Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;

public interface ICloudComputingProvider
{
    Task<IResult<IEnumerable<CloudComputingService>>> GetServices(
        CancellationToken cancellationToken);

    Task<IResult<OrderLicencesResponse>> OrderLicences(Guid accountId, Guid serviceId, int quantity, 
        CancellationToken cancellationToken);

    Task<IResult<ActionResponse>> CancelSubscription(Guid serviceId, Guid accountId,
        CancellationToken cancellationToken);

    Task<IResult<ActionResponse>> ExtendLicence(Guid licenceId, Guid accountId, DateTimeOffset until,
        CancellationToken cancellationToken);

    Task<IResult<ActionResponse>> UpdateLicenceQuantity(Guid serviceId, Guid accountId, int newQuantity,
        CancellationToken cancellationToken);
}
