using MediatR;
using Mobile.UseCases.Orders.Dto;

namespace Mobile.UseCases.Orders.Commands.Create
{
    public class CreateOrderCommand : IRequest<int>
    {
        public CreateOroderDto Dto { get; set; }
    }
}
