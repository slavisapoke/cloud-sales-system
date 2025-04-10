using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Migrations;

public sealed class SeedLicences
{
    static string[] internalIds = [
            "230950e0-fb93-406d-bf9d-61aee5de4506",
            "240950e0-fb93-406d-bf9d-61aee5de4506",
            "250950e0-fb93-406d-bf9d-61aee5de4506",
            "260950e0-fb93-406d-bf9d-61aee5de4506",
            "270950e0-fb93-406d-bf9d-61aee5de4506",
            "280950e0-fb93-406d-bf9d-61aee5de4506",
            "290950e0-fb93-406d-bf9d-61aee5de4506",
            "2a0950e0-fb93-406d-bf9d-61aee5de4506",
            "2b0950e0-fb93-406d-bf9d-61aee5de4506",
            "2c0950e0-fb93-406d-bf9d-61aee5de4506",
            "2d0950e0-fb93-406d-bf9d-61aee5de4506",
            "2e0950e0-fb93-406d-bf9d-61aee5de4506",
            "2f0950e0-fb93-406d-bf9d-61aee5de4506",
            "300950e0-fb93-406d-bf9d-61aee5de4506",
            "310950e0-fb93-406d-bf9d-61aee5de4506",
            "320950e0-fb93-406d-bf9d-61aee5de4506",
            "330950e0-fb93-406d-bf9d-61aee5de4506",
            "340950e0-fb93-406d-bf9d-61aee5de4506",
            "350950e0-fb93-406d-bf9d-61aee5de4506",
            "360950e0-fb93-406d-bf9d-61aee5de4506",
            "370950e0-fb93-406d-bf9d-61aee5de4506",
            "380950e0-fb93-406d-bf9d-61aee5de4506",
            "390950e0-fb93-406d-bf9d-61aee5de4506",
            "3a0950e0-fb93-406d-bf9d-61aee5de4506",
            "3b0950e0-fb93-406d-bf9d-61aee5de4506",
            "3c0950e0-fb93-406d-bf9d-61aee5de4506",
            "3d0950e0-fb93-406d-bf9d-61aee5de4506",
            "3e0950e0-fb93-406d-bf9d-61aee5de4506",
            "3f0950e0-fb93-406d-bf9d-61aee5de4506",
            "400950e0-fb93-406d-bf9d-61aee5de4506"
        ];

      static string[] externalIds = [
        "a511a5be-f12d-4ce5-999e-9f6623de4d54",
        "a611a5be-f12d-4ce5-999e-9f6623de4d54",
        "a711a5be-f12d-4ce5-999e-9f6623de4d54",
        "a811a5be-f12d-4ce5-999e-9f6623de4d54",
        "a911a5be-f12d-4ce5-999e-9f6623de4d54",
        "aa11a5be-f12d-4ce5-999e-9f6623de4d54",
        "ab11a5be-f12d-4ce5-999e-9f6623de4d54",
        "ac11a5be-f12d-4ce5-999e-9f6623de4d54",
        "ad11a5be-f12d-4ce5-999e-9f6623de4d54",
        "ae11a5be-f12d-4ce5-999e-9f6623de4d54",
        "af11a5be-f12d-4ce5-999e-9f6623de4d54",
        "b011a5be-f12d-4ce5-999e-9f6623de4d54",
        "b111a5be-f12d-4ce5-999e-9f6623de4d54",
        "b211a5be-f12d-4ce5-999e-9f6623de4d54",
        "b311a5be-f12d-4ce5-999e-9f6623de4d54",
        "b411a5be-f12d-4ce5-999e-9f6623de4d54",
        "b511a5be-f12d-4ce5-999e-9f6623de4d54",
        "b611a5be-f12d-4ce5-999e-9f6623de4d54",
        "b711a5be-f12d-4ce5-999e-9f6623de4d54",
        "b811a5be-f12d-4ce5-999e-9f6623de4d54",
        "b911a5be-f12d-4ce5-999e-9f6623de4d54",
        "ba11a5be-f12d-4ce5-999e-9f6623de4d54",
        "bb11a5be-f12d-4ce5-999e-9f6623de4d54",
        "bc11a5be-f12d-4ce5-999e-9f6623de4d54",
        "bd11a5be-f12d-4ce5-999e-9f6623de4d54",
        "be11a5be-f12d-4ce5-999e-9f6623de4d54",
        "bf11a5be-f12d-4ce5-999e-9f6623de4d54",
        "c011a5be-f12d-4ce5-999e-9f6623de4d54",
        "c111a5be-f12d-4ce5-999e-9f6623de4d54",
        "c211a5be-f12d-4ce5-999e-9f6623de4d54"
        ];

    public static void Seed(ModelBuilder builder) 
    {
        var entities = new List<LicenceEntity>();

        entities.AddRange(Enumerable.Range(0, 3).Select(ind =>
            Create(Guid.Parse(internalIds[ind]), Guid.Parse(externalIds[ind]), SeedSubscriptions.Account1_Id, SeedSubscriptions.ExternalSub1_id, SeedSubscriptions.Subscription1_Id)));
        
        entities.AddRange(Enumerable.Range(3, 5).Select(ind =>
            Create(Guid.Parse(internalIds[ind]), Guid.Parse(externalIds[ind]), SeedSubscriptions.Account1_Id, SeedSubscriptions.ExternalSub2_id, SeedSubscriptions.Subscription2_Id)));
        
        entities.AddRange(Enumerable.Range(8, 5).Select(ind =>
            Create(Guid.Parse(internalIds[ind]), Guid.Parse(externalIds[ind]), SeedSubscriptions.Account2_Id, SeedSubscriptions.ExternalSub3_id, SeedSubscriptions.Subscription3_Id)));

        builder.Entity<LicenceEntity>()
            .HasData(entities);
    }

    private static Random random = new Random();

    private static LicenceEntity Create(Guid id, Guid externalId, Guid accountId, Guid extSubscriptionId, Guid subscriptionId) =>
        new LicenceEntity
            {
                Id = id,
                AccountId = accountId,
                ExternalLicenceId = externalId ,
                LicenceKey = LicenceGenerator.GenerateSegmentedString('-', 4, 5),
                ExternalSubscriptionId = extSubscriptionId,
                SubscriptionId = subscriptionId,
                Status = LicenceStatus.Active,
                ValidTo = DateTimeOffset.UtcNow.AddDays(random.Next(30, 300))
            };
}
