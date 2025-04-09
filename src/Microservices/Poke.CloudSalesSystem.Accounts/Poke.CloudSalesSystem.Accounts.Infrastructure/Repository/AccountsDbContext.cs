using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Accounts.Domain.Model;
using Poke.CloudSalesSystem.Accounts.Domain.Repository;
using Poke.CloudSalesSystem.Accounts.Infrastructure.Migrations;
using Poke.CloudSalesSystem.Common.Database;

namespace Infrastructure.Repository;

public class AccountsDbContext : BaseDbContext, IAccountsDbContext
{
    public DbSet<AccountEntity> Accounts { get; set; }

    public AccountsDbContext(DbContextOptions<AccountsDbContext> options,
        TimeProvider timeProvider)
        : base(options, timeProvider)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        SeedAccounts.Seed(modelBuilder);
    }
}
