using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.Orders.Dto;
using UseCases.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderWithServicesController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderWithServicesController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            var result = await _orderService.GetByIdAsync(id);
            return result;
        } 
        
        [HttpPost]
        public async Task<int> Create([FromBody] CreateOroderDto dto)
        {
            var result = await _orderService.CreateOrderAsync(dto);
            return result;
        }
    }
}
