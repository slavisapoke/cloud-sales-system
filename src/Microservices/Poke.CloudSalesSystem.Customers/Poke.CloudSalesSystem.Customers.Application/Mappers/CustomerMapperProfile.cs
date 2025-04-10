using AutoMapper;
using Poke.CloudSalesSystem.Common.Contracts.Customers;
using Poke.CloudSalesSystem.Customers.Domain.Model;

namespace Poke.CloudSalesSystem.Customers.Application.Mappers;

public class CustomerMapperProfile : Profile
{
    public CustomerMapperProfile()
    {
        CreateMap<CustomerEntity, Customer>();
    }
}
