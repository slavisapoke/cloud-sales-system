
using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Domain.Repository;

public interface ILicencesDbContext
{
    DbSet<ServiceEntity> Services { get; set; }
    DbSet<LicenceEntity> Licences { get; set; }
    DbSet<SubscriptionEntity> Subscriptions { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
