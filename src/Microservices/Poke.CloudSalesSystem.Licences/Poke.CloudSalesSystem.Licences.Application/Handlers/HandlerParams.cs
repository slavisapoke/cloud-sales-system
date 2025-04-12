using AutoMapper;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;
using Poke.CloudSalesSystem.Licences.Application.Abstract;
using Poke.CloudSalesSystem.Licences.Domain.Repository;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers;

public record HandlerParams<T>(
     ICloudComputingProvider CloudComputingProvider,
     IEventPublisher EventPublisher,
     ILicencesDbContext DB, 
     TimeProvider TimeProvider,
     ILogger<T> Logger,
     IMapper Mapper)
{ }