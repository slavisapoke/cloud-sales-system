using Poke.CloudSalesSystem.Accounts.Infrastructure;
using Poke.CloudSalesSystem.Accounts.Application;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository;
using Polly;

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

        var retryPolicy = Policy.Handle<Npgsql.NpgsqlException>()
            .WaitAndRetry(10,
            attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)), //exponential backoff
            (exception, timeSpan, attempt, context) =>
            {
                logger.LogError($"Running DB migrations attempt {attempt} failed. Retrying in {timeSpan.TotalSeconds} seconds. Exception: {exception.Message}");
            });

        using var dbContext = scope.ServiceProvider.GetRequiredService<AccountsDbContext>();

        retryPolicy.Execute(() =>
        {
            dbContext.Database.Migrate();
            logger.LogInformation($"Migrations completed");
        });
    }
}
