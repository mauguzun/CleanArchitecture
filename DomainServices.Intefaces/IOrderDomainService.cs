using Domain.Entities;

namespace DomainServices.Intefaces
{
    public interface IOrderDomainService
    {
        decimal GetTotal(Order order);
    }
}