using Domain.Entities;
using DomainServices.Intefaces;

namespace DomainServices.Implementation
{
    public class  OrderDomainService :IOrderDomainService
    {
        public decimal GetTotal(Order order) => order.Items.Sum(x => x.Quantity * x.Product.Price);

    }
}