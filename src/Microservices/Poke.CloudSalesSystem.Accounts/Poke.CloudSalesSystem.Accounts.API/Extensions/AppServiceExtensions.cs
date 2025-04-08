using Poke.CloudSalesSystem.Accounts.Infrastructure;
using Poke.CloudSalesSystem.Accounts.Application;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository;

namespace Poke.CloudSalesSystem.Accounts.API.Extensions;

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
            //Add resilience 
            using var dbContext = scope.ServiceProvider.GetRequiredService<AccountsDbContext>();
            dbContext.Database.Migrate();
        }
        catch(Exception ex)
        {
            logger.LogError(ex, $"Migration failed to db: {ex}");
        }
    }
}
