using MediatR;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Customers.Common.Constants;

namespace Poke.CloudSalesSystem.Customers.Application.Pipeline;

public class LogBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public LogBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestType = request.GetType().Name;

        try
        {
            _logger.LogInformation($"Executing {requestType} {LogPlaceholders.REQUEST_DATA}", request);

            var result = await next();

            return result;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"{requestType} processing failed");

            throw;
        }
    }
}