using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Contracts.Events.Events.System;
using Poke.CloudSalesSystem.Licences.Application.Abstract;
using EventCodes = Poke.CloudSalesSystem.Contracts.Events.Events.Constants.Codes;

namespace Poke.CloudSalesSystem.Licences.Application.Pipeline
{
    internal class LogBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IServiceProvider _serviceProvider;

        public LogBehavior(ILogger<TRequest> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestType = request.GetType().Name;

            try
            {
                _logger.LogInformation($"Executing {requestType} {LogPlaceholders.REQUEST}", request);

                var result = await next();

                return result;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"{requestType} processing failed");

                var eventPublisher = _serviceProvider.GetRequiredService<IEventPublisher>();

                await eventPublisher.Publish(ActionFailedEvent.Create(EventCodes.Error.HELL_AND_FIRE,
                    request, exception.Message));

                throw;
            }
        }
    }
}
