
using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Licenses.Domain.Model;

namespace Poke.CloudSalesSystem.Licenses.Domain.Repository;

public interface ILicensesDbContext
{
    DbSet<ServiceEntity> Services { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
