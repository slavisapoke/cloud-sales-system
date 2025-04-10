using FluentResults;
using Poke.CloudSalesSystem.Licences.Application.Model.CloudComputing;

namespace Poke.CloudSalesSystem.Licences.Application.Abstraction;

public interface ICloudComputingProvider
{
    Task<IResult<IEnumerable<CloudComputingService>>> GetServices(
        CancellationToken cancellationToken);

    Task<IResult<OrderLicencesResponse>> OrderLicences(Guid accountId, Guid serviceId, int quantity, 
        CancellationToken cancellationToken);
}
