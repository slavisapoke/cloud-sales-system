using Poke.CloudSalesSystem.Customers.Infrastructure;
using Poke.CloudSalesSystem.Customers.Application;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository;

namespace Poke.CloudSalesSystem.Customers.API.Extensions;

public static class AppServiceExtensions
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterApplication(configuration);
        services.RegisterInfrastructure(configuration);

        return services;
    }

    public static void StartMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        try
        {
            using var dbContext = scope.ServiceProvider.GetRequiredService<CustomersDbContext>();
            dbContext.Database.Migrate();
        }
        catch(Exception ex)
        {
            logger.LogError(ex, $"Migration failed to db: {ex}");
        }
    }
}
