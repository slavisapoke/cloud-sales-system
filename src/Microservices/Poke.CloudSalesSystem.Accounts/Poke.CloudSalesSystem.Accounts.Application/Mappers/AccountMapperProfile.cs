using AutoMapper;
using Poke.CloudSalesSystem.Accounts.Domain.Model;
using Poke.CloudSalesSystem.Common.Contracts.Accounts;

namespace Poke.CloudSalesSystem.Accounts.Application.Mappers;

public class AccountMapperProfile : Profile
{
    public AccountMapperProfile()
    {
        CreateMap<AccountEntity, Account>();
    }
}
