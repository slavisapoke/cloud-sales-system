using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Contracts.Licences;
using Poke.CloudSalesSystem.Contracts.Events.Events.Licences;
using Poke.CloudSalesSystem.Licences.Application.Abstract;
using Poke.CloudSalesSystem.Licences.Domain.Repository;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Workers;

/// <summary>
/// Licence expiration worker example (here, nothing smart to see :)
/// </summary>
/// <param name="serviceProvider"></param>
/// <param name="logger"></param>
public  class LicenceExpirationWorker(
    IServiceProvider serviceProvider,
    ILogger<LicenceExpirationWorker> logger) : BackgroundService
{
    //should be configurable
    private const int NEAR_EXPIRATION_TIMEOFFSET_IN_DAYS = 10;

    //should be configurable (in prod possibly once a day
    private static TimeSpan LOOP_WAIT = TimeSpan.FromMinutes(2);  //just for test to check message publishing

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(LicenceExpirationWorker)} is starting.");

        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ILicencesDbContext>();
        var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();
        var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

        while (!cancellationToken.IsCancellationRequested)
        {
            logger.LogInformation($"{nameof(LicenceExpirationWorker)} checking licence expiration at {DateTime.UtcNow}");

            await NearExpirationCheck(dbContext, mapper, eventPublisher);
            await JustExpiredLicenceCheck(dbContext, mapper, eventPublisher);

            await Task.Delay(LOOP_WAIT, cancellationToken);
        }

        logger.LogInformation($"{nameof(LicenceExpirationWorker)} is stopping.");
    }

    private async Task NearExpirationCheck(ILicencesDbContext context, IMapper mapper, IEventPublisher eventPublisher)
    {
        try
        {  
            var nearExpiration = await context.Licences
               .Where(l => l.ValidTo.HasValue && 
                   l.ValidTo.Value > DateTime.Now && 
                   l.ValidTo.Value.AddDays(-NEAR_EXPIRATION_TIMEOFFSET_IN_DAYS) < DateTime.UtcNow).ToListAsync();

            if (nearExpiration == null || !nearExpiration.Any())
            {
                return;
            }

            await eventPublisher.Publish(new LicencesNearExpiration(mapper.Map<IReadOnlyCollection<Licence>>(nearExpiration)));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"{nameof(LicenceExpirationWorker)} failed while checking near-expiration licences");
        }
    }

    private async Task JustExpiredLicenceCheck(ILicencesDbContext context, IMapper mapper, IEventPublisher eventPublisher)
    {
        try
        {
            var justExpired = await context.Licences
                .Where(l => 
                    l.Status == Domain.Model.LicenceStatus.Active &&
                    l.ValidTo.HasValue && l.ValidTo.Value < DateTime.Now && 
                    l.ValidTo.Value.AddHours(1) > DateTime.UtcNow).ToListAsync();

            if (justExpired == null || !justExpired.Any())
            {
                return;
            }

            //please, just don't! Batch it baby!
            foreach(var licence in justExpired)
            {
                await eventPublisher.Publish(new LicenceExpired(mapper.Map<Licence>(licence)));
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"{nameof(LicenceExpirationWorker)} failed while checking just expired licences");
        }
    } 
}
