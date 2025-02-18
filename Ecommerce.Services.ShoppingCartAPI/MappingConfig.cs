﻿using AutoMapper;
using Ecommerce.Services.ShoppingCartAPI.Models;
using Ecommerce.Services.ShoppingCartAPI.Models.Dto;

namespace Ecommerce.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }

    }
}
