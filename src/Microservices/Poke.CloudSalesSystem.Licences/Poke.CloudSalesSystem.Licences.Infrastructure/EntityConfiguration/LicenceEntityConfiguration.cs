using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.EntityConfiguration;

public class LicenceEntityConfiguration : IEntityTypeConfiguration<LicenceEntity>
{
    public void Configure(EntityTypeBuilder<LicenceEntity> builder)
    {
        builder.ToTable("licences");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.LicenceKey)
           .HasMaxLength(50);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.ExternalSubscriptionId)
            .IsRequired();

        builder.Property(x => x.ExternalLicenceId)
            .IsRequired();

        builder.HasOne(x => x.Subscription)
            .WithMany(sub => sub.Licences)
            .HasForeignKey(x => x.SubscriptionId);
    }
}
