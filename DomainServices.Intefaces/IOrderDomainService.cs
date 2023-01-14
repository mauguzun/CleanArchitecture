using Entities.Models;

namespace DomainServices.Intefaces
{
    public interface IOrderDomainService
    {
        decimal GetTotal(Order order);
    }
}