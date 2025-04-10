using RichardSzalay.MockHttp;
using System.Net.Http.Json;
using System.Net;
using Poke.CloudSalesSystem.Licences.Application.Model.CloudComputing;
using Poke.CloudSalesSystem.Licences.Infrastructure.Migrations;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Licences.Application.Model;

namespace Poke.CloudSalesSystem.Licences.Infrastructure.ExternalServices.CCP.MockHttp;

internal class MockHttpClientBuilder
{
    private string _serviceUrl;
    private MockHttpMessageHandler handler;
    private readonly Guid providerId = Guid.Parse("8d206b9f-d4b6-449c-b898-3c973cfe4a69");

    public MockHttpClientBuilder(string serviceUrl)
    {
        _serviceUrl = serviceUrl;
        handler = new MockHttpMessageHandler();
    }

    public MockHttpClientBuilder WithGetAllServices()
    {
        handler.When($"{_serviceUrl}/services")
            .Respond(HttpStatusCode.OK,
                JsonContent.Create(GetAllServices()));
        return this;
    }

    public MockHttpClientBuilder WithOrderLicences(Guid accountId, Guid serviceId, int quantity)
    {
        var endpoint = $"{_serviceUrl}/services/${serviceId}/account/${accountId}/{quantity}";

        var service = GetAllServices().
            Where(s => s.Id == serviceId).FirstOrDefault();


        if (service is null)
        {
            handler.When(endpoint)
               .Respond(HttpStatusCode.NotFound,
                   JsonContent.Create(new { Error = $"Service {serviceId} not found"}));
            return this;
        }

        OrderLicencesResponse response;

        //Account 1 has services 1 and 2
        //for this case return requested number of new licences with appropriate subscription
        if (SeedSubscriptions.Account1_Id == accountId && 
            (serviceId == SeedServices.Service1_Id || serviceId == SeedServices.Service2_Id))
        {
            Guid subscriptionId = serviceId == SeedServices.Service1_Id ?
                SeedSubscriptions.ExternalSub1_id : SeedSubscriptions.ExternalSub2_id;

            var licences = GenerateLicences(quantity, subscriptionId);
            response = new OrderLicencesResponse(
                subscriptionId,
                serviceId,
                service.Name,
                licences,
                OrderStatus.LicencesAquired,
                string.Empty);
        }
        //In case of account 2 for service 2 (which he has subscription to) 
        //return partial response since he requested more than available
        else if(accountId == SeedSubscriptions.Account2_Id && serviceId == SeedServices.Service2_Id)
        {
            var licences = GenerateLicences(quantity/2, SeedSubscriptions.ExternalSub3_id);
            response = new OrderLicencesResponse(
                SeedSubscriptions.ExternalSub3_id,
                serviceId,
                service.Name,
                licences,
                OrderStatus.LicencesAquiredPartially,
                "Number of requested licences partially aquired");
        }
        //for some reason this account fails to order
        else if (accountId == SeedSubscriptions.Account3_Id_FailsToOrder)
        {
            var subscriptionId = Guid.NewGuid();
            response = new OrderLicencesResponse(
                subscriptionId,
                serviceId,
                service.Name,
                [],
                OrderStatus.OrderFailed,
                "Some error who knows what...");
        }
        //else for all other accounts just return new subscriptionId and licences
        else
        {
            var subscriptionId = Guid.NewGuid();
            var licences = GenerateLicences(quantity, subscriptionId);
            response = new OrderLicencesResponse(
                subscriptionId,
                serviceId,
                service.Name,
                licences,
                OrderStatus.NewSubscription,
                string.Empty);
        }

        handler.When(endpoint)
            .Respond(HttpStatusCode.OK,
                JsonContent.Create(response));

        return this;
    }

    public HttpClient Build() => handler.ToHttpClient();

    private Random random = new Random();
    private IEnumerable<CloudComputingLicence> GenerateLicences(
        int quantity,
        Guid subscriptionId) =>
        Enumerable.Range(0, quantity)
        .Select(s => new CloudComputingLicence
        {
            Id = Guid.NewGuid(),
            SubscriptionId = subscriptionId,
            LicenceKey = LicenceGenerator.GenerateSegmentedString('-', 4, 5),
            Status = Status.Active,
            ValidTo = DateTime.UtcNow.AddDays(random.Next(30, 365))
        }).ToList();


    private IEnumerable<CloudComputingService> GetAllServices() =>
        new List<CloudComputingService>
        {
            new()
            {
                Id = SeedServices.Service1_Id,
                Name = "Service 1",
                Description = "Service description 1...",
                ProviderId = providerId
            },
            new()
            {
                Id = SeedServices.Service2_Id,
                Name = "Service 2",
                Description = "Service description 2...",
                ProviderId = providerId
            },
            new()
            {
                Id = Guid.Parse("05b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 3",
                Description = "Service description 3...",
                ProviderId = providerId
            },
            new()
            {
                Id = Guid.Parse("06b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 4",
                Description = "Service description 4...",
                ProviderId = providerId
            },
            new()
            {
                Id = Guid.Parse("07b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 5",
                Description = "Service description 5...",
                ProviderId = providerId
            },
            new()
            {
                Id = Guid.Parse("08b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 6",
                Description = "Service description 6...",
                ProviderId = providerId
            },
            new()
            {
                Id = Guid.Parse("09b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 7",
                Description = "Service description 7...",
                ProviderId = providerId
            },
            new()
            {
                Id = Guid.Parse("0ab2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 8",
                Description = "Service description 8...",
                ProviderId = providerId
            },
            new()
            {
                Id = Guid.Parse("0bb2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 9",
                Description = "Service description 9...",
                ProviderId = providerId
            },
            new()
            {
                Id = Guid.Parse("d384eb26-9d42-4c16-89cb-ce75e0ab5afa"),
                Name = "Service 2",
                Description = "Service description 2...",
                ProviderId = providerId
            },
            new()
            {
                Id = Guid.Parse("0cb2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 10",
                Description = "Service description 10...",
                ProviderId = providerId
            }
        };
}
