using FluentResults;
using MediatR;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers;

public interface IRequestWithFluentResult<T> : IRequest<IResult<T>>;
