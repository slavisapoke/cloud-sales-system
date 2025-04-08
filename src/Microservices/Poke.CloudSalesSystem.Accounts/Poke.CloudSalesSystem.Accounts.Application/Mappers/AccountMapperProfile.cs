using AutoMapper;
using Poke.CloudSalesSystem.Accounts.Application.Model;
using Poke.CloudSalesSystem.Accounts.Domain.Model;

namespace Poke.CloudSalesSystem.Accounts.Application.Mappers;

public class AccountMapperProfile : Profile
{
    public AccountMapperProfile()
    {
        CreateMap<AccountEntity, Account>();
    }
}
