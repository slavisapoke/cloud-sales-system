using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Migrations;

public sealed class SeedSubscriptions
{
    public static Guid Account1_Id = Guid.Parse("61db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account2_Id = Guid.Parse("62db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account3_Id_FailsToOrder = Guid.Parse("63db564e-5ef0-4614-9127-562a8b2856db");

    public static Guid Subscription1_Id = Guid.Parse("2284eda3-29ec-4bf1-b077-225a2bcbfdc1");
    public static Guid Subscription2_Id = Guid.Parse("2384eda3-29ec-4bf1-b077-225a2bcbfdc1");
    public static Guid Subscription3_Id = Guid.Parse("2484eda3-29ec-4bf1-b077-225a2bcbfdc1");

    public static Guid ExternalSub1_id = Guid.Parse("b337547d-4f1c-4b17-b464-8e4e28899a8b");
    public static Guid ExternalSub2_id = Guid.Parse("b437547d-4f1c-4b17-b464-8e4e28899a8b");
    public static Guid ExternalSub3_id = Guid.Parse("b537547d-4f1c-4b17-b464-8e4e28899a8b");

    public static void Seed(ModelBuilder builder)
    {
        List<SubscriptionEntity> subscriptions = [
                new SubscriptionEntity
                {
                    Id = Subscription1_Id,
                    ExternalSubscriptionId = ExternalSub1_id,
                    AccountId = Account1_Id,
                    Quantity = 5,
                    ServiceId = SeedServices.Service1_Id,
                    ServiceName = "Service 1 name...",
                    Status = SubscriptionStatus.Active
                },
                new SubscriptionEntity
                {
                    Id = Subscription2_Id,
                    ExternalSubscriptionId = ExternalSub2_id,
                    AccountId = Account1_Id,
                    Quantity = 10,
                    ServiceId = SeedServices.Service2_Id,
                    ServiceName = "Service 2 name...",
                    Status = SubscriptionStatus.Active
                },
                new SubscriptionEntity
                {
                    Id = Subscription3_Id,
                    ExternalSubscriptionId = ExternalSub3_id,
                    AccountId = Account2_Id,
                    Quantity = 15,
                    ServiceId = SeedServices.Service2_Id,
                    ServiceName = "Service 2 name...",
                    Status = SubscriptionStatus.Active
                }];

        builder.Entity<SubscriptionEntity>()
            .HasData(subscriptions);
    }
}
