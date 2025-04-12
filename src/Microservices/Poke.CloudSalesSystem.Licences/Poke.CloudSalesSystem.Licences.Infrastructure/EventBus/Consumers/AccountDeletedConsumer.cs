using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Common.Contracts.Licences;
using Poke.CloudSalesSystem.Contracts.Events.Events.Accounts;
using Poke.CloudSalesSystem.Licences.Domain.Repository;
using SubscriptionContract = Poke.CloudSalesSystem.Common.Contracts.Licences.Subscription;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.EventBus.Consumers
{
    public class AccountDeletedConsumer(
        IMapper mapper,
        ILicencesDbContext dbContext,
        ILogger<AccountDeletedConsumer> logger) : IConsumer<AccountDeleted>
    {
        public async Task Consume(ConsumeContext<AccountDeleted> context)
        {
            try
            {
                var message = context.Message;

                var subscriptions = await dbContext.Subscriptions
                    .Include(s => s.Licences)
                    .Where(s => s.AccountId == message.AccountId)
                    .ToListAsync();

                if (subscriptions is null || !subscriptions.Any())
                {
                    return; //nothing to do here
                }

                foreach (var subscription in subscriptions)
                {
                    subscription.Status = Domain.Model.SubscriptionStatus.Suspended;

                    foreach (var licence in subscription.Licences)
                    {
                        licence.Status = Domain.Model.LicenceStatus.Suspended;
                    }
                }

                await dbContext.SaveChangesAsync();

                var subs = mapper.Map<IReadOnlyCollection<SubscriptionContract>>(subscriptions);
                var lics = mapper.Map<IReadOnlyCollection<Licence>>(subscriptions.SelectMany(s => s.Licences));

                try { await context.Publish(subs); } catch { }
                try { await context.Publish(lics); } catch { }
            }
            catch (Exception ex)
            {
                //do something smarter, if some compesating transation is needed, implement SAGA
                logger.LogError(ex, $"[Consume] failed. {LogPlaceholders.MESSAGE}", context.Message);
            }
        }
    }
}
