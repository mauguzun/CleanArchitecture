using AutoMapper;
using Domain.Entities;
using UseCases.Orders.Dto;

namespace UseCases.Orders.Utils
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
