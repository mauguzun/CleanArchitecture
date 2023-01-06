using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IOrderService
    {
        Task<OrderDto> GetByIdAsync(int id);
        Task<int> CreateOrderAsync(CreateOroderDto order);
    }
}
