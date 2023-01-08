using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mobile.UseCases.Orders.Commands.Create;
using Mobile.UseCases.Orders.Dto;
using Mobile.UseCases.Orders.Queries.GetOrderBy;

namespace Mobile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _sender;

        public OrdersController(ISender orderService)
        {
            _sender = orderService;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            var result = await _sender.Send(new GetOrderByIdQuery() { Id = id });

            return result;
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateOroderDto dto)
        {
            var result = await _sender.Send(new CreateOrderCommand() { Dto = dto });

            return result;
        }
    }
}
