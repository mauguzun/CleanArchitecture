using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Orders.Dto;

namespace UseCases.Services
{
    public interface IOrderService
    {
        Task<OrderDto> GetByIdAsync(int id);
        Task<int> CreateOrderAsync(CreateOroderDto order);
    }
}
