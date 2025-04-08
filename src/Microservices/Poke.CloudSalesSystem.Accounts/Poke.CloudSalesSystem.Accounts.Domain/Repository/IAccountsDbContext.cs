
using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Accounts.Domain.Model;

namespace Poke.CloudSalesSystem.Accounts.Domain.Repository;

public interface IAccountsDbContext
{
    DbSet<AccountEntity> Accounts { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
