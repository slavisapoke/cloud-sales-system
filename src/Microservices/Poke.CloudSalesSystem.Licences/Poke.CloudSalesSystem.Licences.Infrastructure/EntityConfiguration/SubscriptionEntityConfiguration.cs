using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.EntityConfiguration;

public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<SubscriptionEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionEntity> builder)
    {
        builder.ToTable("subscriptions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AccountId)
            .IsRequired();

        builder.Property(x => x.Quantity)
           .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.ExternalSubscriptionId)
            .IsRequired();

        builder.Property(x => x.ServiceName)
            .IsRequired();
          
        builder.HasMany(x => x.Licences)
            .WithOne(lic => lic.Subscription)
            .HasForeignKey(x => x.SubscriptionId);

        builder.HasOne(x => x.Service)
            .WithMany(ser => ser.Subscriptions)
            .HasForeignKey(sub => sub.ServiceId);
    }
}
