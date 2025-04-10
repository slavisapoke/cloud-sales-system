using AutoMapper;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;
using Poke.CloudSalesSystem.Common.Contracts.Licences;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Application.Mappers;

public class LicencesMapperProfile : Profile
{
    public LicencesMapperProfile()
    {
        CreateMap<LicenceEntity, Licence>();
        CreateMap<SubscriptionEntity, Subscription>();
        CreateMap<ServiceEntity, Service>();

        CreateMap<CloudComputingLicence, LicenceEntity>()
            .ForMember(x => x.ExternalLicenceId, opt => opt.MapFrom(y => y.Id))
            .ForMember(x => x.ExternalSubscriptionId, opt => opt.MapFrom(y => y.SubscriptionId));
    }
}
