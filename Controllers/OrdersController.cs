using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases;
using UseCases.Orders.Commands.Create;
using UseCases.Orders.Dto;
using UseCases.Orders.Queries.GetOrderBy;
using UseCases.Services;

namespace WebApp.Controllers
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
