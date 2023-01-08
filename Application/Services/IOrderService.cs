using Mobile.UseCases.Orders.Dto;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.UseCases.Services
{
    public interface IOrderService
    {
        Task<OrderDto> GetByIdAsync(int id);
        Task<int> CreateOrderAsync(CreateOroderDto order);
    }
}
