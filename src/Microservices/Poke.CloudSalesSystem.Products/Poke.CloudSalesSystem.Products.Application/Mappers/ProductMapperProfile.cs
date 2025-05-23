﻿using AutoMapper;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;
using Poke.CloudSalesSystem.Common.Contracts.Products;

namespace Poke.CloudSalesSystem.Products.Application.Mappers;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<CloudComputingService, Product>();
    }
}
