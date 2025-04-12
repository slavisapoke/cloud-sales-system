using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

namespace Poke.CloudSalesSystem.Gateway.Tests.Factory
{
    public class ApiTestFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {   
            builder.ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IAccountService));

                if (descriptor != null) services.Remove(descriptor);

                var accountServiceMock = new Mock<IAccountService>();

                accountServiceMock.Setup(x => x.GetAll(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync([]);

                services.AddSingleton(accountServiceMock.Object);
            });
        }


        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
