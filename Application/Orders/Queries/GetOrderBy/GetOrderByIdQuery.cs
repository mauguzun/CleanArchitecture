using MediatR;
using Mobile.UseCases.Orders.Dto;

namespace Mobile.UseCases.Orders.Queries.GetOrderBy
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
