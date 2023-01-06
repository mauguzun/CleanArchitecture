using MediatR;
using UseCases.Orders.Dto;

namespace UseCases.Orders.Queries.GetOrderBy
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
