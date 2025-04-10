using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;
using Poke.CloudSalesSystem.Gateway.Infrastructure.Services.Downstream;

namespace Poke.CloudSalesSystem.Gateway.Infrastructure;

public static class DIExtensions
{
    public static IServiceCollection RegisterInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        //.net8 preview contains TimeProvider.System
        services.AddTransient<TimeProvider, CustomTimeProvider>();

        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<ILicenceService, LicenceService>();
        
        return services;
    }
}
