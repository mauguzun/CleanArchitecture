using System.Collections.Generic;

namespace UseCases.Orders.Dto
{
    public class CreateOroderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}
