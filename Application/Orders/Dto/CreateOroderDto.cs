using System.Collections.Generic;

namespace Mobile.UseCases.Orders.Dto
{
    public class CreateOroderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}
