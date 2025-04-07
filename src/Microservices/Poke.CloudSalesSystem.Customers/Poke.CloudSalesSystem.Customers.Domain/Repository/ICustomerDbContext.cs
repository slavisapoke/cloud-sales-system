
using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Customers.Domain.Model;

namespace Poke.CloudSalesSystem.Customers.Domain.Repository;

public interface ICustomerDbContext
{
    DbSet<CustomerEntity> Customers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
