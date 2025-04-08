using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Licences.Domain.Repository;

namespace Poke.CloudSalesSystem.Licences.Infrastructure;

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

        services.AddDbContext<LicencesDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseCamelCaseNamingConvention();
        });
        services.AddScoped<ILicencesDbContext>(provider => provider.GetRequiredService<LicencesDbContext>());

        return services;
    }
}
