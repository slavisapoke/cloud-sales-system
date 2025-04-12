using FluentResults;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;

namespace Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;

public interface ICloudComputingProvider
{
    /// <summary>
    /// Gets all services from Cloud Computing Provider
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IResult<IEnumerable<CloudComputingService>>> GetServices(
        CancellationToken cancellationToken);

    /// <summary>
    /// Order new licences for the given account and service
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="serviceId"></param>
    /// <param name="quantity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IResult<OrderLicencesResponse>> OrderLicences(Guid accountId, Guid serviceId, int quantity, 
        CancellationToken cancellationToken);

    /// <summary>
    /// Cancels service subscription for the given account
    /// </summary>
    /// <param name="serviceId"></param>
    /// <param name="accountId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IResult<ActionResponse>> CancelSubscription(Guid serviceId, Guid accountId,
        CancellationToken cancellationToken);

    /// <summary>
    /// Extends licence duration and activates it immediatelly
    /// </summary>
    /// <param name="licenceId"></param>
    /// <param name="accountId"></param>
    /// <param name="until"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IResult<ActionResponse>> ExtendLicence(Guid licenceId, Guid accountId, DateTimeOffset until,
        CancellationToken cancellationToken);

    /// <summary>
    /// Updates licence quantity of provided service for the given account
    /// </summary>
    /// <param name="serviceId"></param>
    /// <param name="accountId"></param>
    /// <param name="newQuantity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IResult<ActionResponse>> UpdateLicenceQuantity(Guid serviceId, Guid accountId, int newQuantity,
        CancellationToken cancellationToken);
}
