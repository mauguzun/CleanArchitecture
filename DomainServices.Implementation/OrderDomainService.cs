using DomainServices.Intefaces;
using Entities.Models;

namespace DomainServices.Implementation
{
    public class  OrderDomainService :IOrderDomainService
    {
      
        public decimal GetTotal(Order order, CalculcateDeliveryCost deliveryCost)
        {
            var totalPrice = order.Items.Sum(x => x.Product.Weight);

            if (totalPrice < 1000)
            {
                var totalWeight = order.Items.Sum(x => x.Product.Weight);
                totalPrice += (float)deliveryCost(totalWeight);
            }

            return (decimal)totalPrice;
        }
    }
}