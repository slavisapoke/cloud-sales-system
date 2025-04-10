using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;
using Poke.CloudSalesSystem.Common.Helpers;
using RichardSzalay.MockHttp;
using System.Net;
using System.Net.Http.Json;

namespace Poke.CloudSalesSystem.Common.CloudComputingClient.MockHttp;

internal class MockHttpClientBuilder
{
    private string _serviceUrl;
    private MockHttpMessageHandler handler;

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
        var endpoint = $"{_serviceUrl}/order/{serviceId}/account/{accountId}/{quantity}";

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
        if (TestData.Account1_Id == accountId && 
            (serviceId == TestData.Service1_Id || serviceId == TestData.Service2_Id))
        {
            Guid subscriptionId = serviceId == TestData.Service1_Id ?
                TestData.ExternalSub1_id : TestData.ExternalSub2_id;

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
        else if(accountId == TestData.Account2_Id && serviceId == TestData.Service2_Id)
        {
            var licences = GenerateLicences(quantity/2, TestData.ExternalSub3_id);
            response = new OrderLicencesResponse(
                TestData.ExternalSub3_id,
                serviceId,
                service.Name,
                licences,
                OrderStatus.LicencesAquiredPartially,
                "Number of requested licences partially aquired");
        }
        //for some reason this account fails to order
        else if (accountId == TestData.Account3_Id_FailsToOrder)
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

    public MockHttpClientBuilder WithCancelSubscription(Guid serviceId, Guid accountId )
    {
        var service = GetAllServices().FirstOrDefault(s => s.Id == serviceId);
        var endpoint = $"{_serviceUrl}/services/{serviceId}/account/{accountId}/cancel";

        if (service is null)
        {
            handler.When(endpoint)
                .Respond(HttpStatusCode.NotFound,
                    JsonContent.Create($"Service not found with Id {serviceId}"));
        }

        handler.When(endpoint)
            .Respond(HttpStatusCode.OK,
                JsonContent.Create(CancelSubscriptionResponse.Success()));

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


    private IEnumerable<CloudComputingService> GetAllServices() => TestData.Services;
 
}
