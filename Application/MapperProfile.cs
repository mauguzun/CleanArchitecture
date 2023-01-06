﻿using AutoMapper;
using Domain.Entities;

namespace Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOroderDto, Order>();
            CreateMap<OrderItemDto, Order>();
        }
    }
}
