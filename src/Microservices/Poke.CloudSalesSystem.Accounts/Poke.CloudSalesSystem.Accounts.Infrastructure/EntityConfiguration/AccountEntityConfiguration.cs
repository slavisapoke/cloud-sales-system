using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poke.CloudSalesSystem.Accounts.Domain.Model;

namespace Poke.CloudSalesSystem.Accounts.Infrastructure.EntityConfiguration;

public class AccountEntityConfiguration : IEntityTypeConfiguration<AccountEntity>
{
    public void Configure(EntityTypeBuilder<AccountEntity> builder)
    {
        builder.ToTable("accounts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CustomerId)
           .IsRequired();

        builder.Property(x => x.Name)
           .IsRequired()
           .HasMaxLength(50);

        builder.Property(x => x.Email)
            .HasMaxLength(100);

        builder.Property(x => x.Phone)
            .HasMaxLength(30);
    }
}
