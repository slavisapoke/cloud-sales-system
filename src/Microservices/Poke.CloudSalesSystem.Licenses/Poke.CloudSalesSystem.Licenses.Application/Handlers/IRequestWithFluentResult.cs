using FluentResults;
using MediatR;

namespace Poke.CloudSalesSystem.Licenses.Application.Handlers;

public interface IRequestWithFluentResult<T> : IRequest<IResult<T>>;
