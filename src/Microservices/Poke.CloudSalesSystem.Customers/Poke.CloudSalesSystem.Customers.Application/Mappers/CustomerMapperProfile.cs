using AutoMapper;
using Poke.CloudSalesSystem.Customers.Application.Model;
using Poke.CloudSalesSystem.Customers.Domain.Model;

namespace Poke.CloudSalesSystem.Customers.Application.Mappers;

public class CustomerMapperProfile : Profile
{
    public CustomerMapperProfile()
    {
        CreateMap<CustomerEntity, Customer>();
    }
}
