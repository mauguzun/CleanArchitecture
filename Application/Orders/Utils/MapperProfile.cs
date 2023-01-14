using AutoMapper;
using Entities.Models;
using Mobile.UseCases.Orders.Commands.Create;
using Mobile.UseCases.Orders.Dto;

namespace Mobile.UseCases.Orders.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<CreateOroderDto, Order>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<OrderItemDto, Order>().ReverseMap();

            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(dest => dest.ProductId,opt => opt.MapFrom(x=>x.Id));

        }
    }
}
