using MediatR;
using UseCases.Orders.Dto;

namespace UseCases.Orders.Commands.Create
{
    public class CreateOrderCommand : IRequest<int>
    {
        public CreateOroderDto Dto { get; set; }
    }
}
