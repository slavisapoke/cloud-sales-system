using AutoMapper;
using Poke.CloudSalesSystem.Licences.Application.Model;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Application.Mappers;

public class LicencesMapperProfile : Profile
{
    public LicencesMapperProfile()
    {
        CreateMap<LicenceEntity, Licence>();
        CreateMap<SubscriptionEntity, Subscription>();
        CreateMap<ServiceEntity, Service>();
    }
}
