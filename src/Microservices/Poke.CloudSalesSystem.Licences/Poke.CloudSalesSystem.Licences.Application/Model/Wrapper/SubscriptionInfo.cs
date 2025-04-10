using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Application.Model.Wrapper;

public record SubscriptionInfo(
    SubscriptionEntity Subscription, 
    int NumberOfLicences, 
    int NumberOfActiveLicences);
