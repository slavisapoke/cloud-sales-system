using Poke.CloudSalesSystem.Licences.Infrastructure;
using Poke.CloudSalesSystem.Licences.Application;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository;
using Polly;

namespace Poke.CloudSalesSystem.Licences.API.Extensions;

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
            .WaitAndRetry(5,
            attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)), //exponential backoff
            (exception, timeSpan, attempt, context) =>
            {
                logger.LogError($"Running DB migrations attempt {attempt} failed. Retrying in {timeSpan.TotalSeconds} seconds. Exception: {exception.Message}");
            });

        using var dbContext = scope.ServiceProvider.GetRequiredService<LicencesDbContext>();

        retryPolicy.Execute(() =>
        {
            dbContext.Database.Migrate();
            logger.LogInformation($"Migrations completed");
        });
    }
}
