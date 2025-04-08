using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Licenses.Domain.Repository;

namespace Poke.CloudSalesSystem.Licenses.Infrastructure;

public static class DIExtensions
{
    public static IServiceCollection RegisterInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        //.net8 preview contains TimeProvider.System
        services.AddScoped<TimeProvider, CustomTimeProvider>();

        var connectionString =
           configuration.GetConnectionString("Postgres") ??
           throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<LicensesDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseCamelCaseNamingConvention();
        });
        services.AddScoped<ILicensesDbContext>(provider => provider.GetRequiredService<LicensesDbContext>());

        return services;
    }
}
