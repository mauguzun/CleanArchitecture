using AutoMapper;
using Domain.Entities;
using Mobile.UseCases.Orders.Dto;

namespace Mobile.UseCases.Orders.Utils
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
