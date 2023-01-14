using Delivery.Interfaces;
using DomainServices.Intefaces;
using Entities.Models;

namespace DomainServices.Implementation
{
    public class  OrderDomainService :IOrderDomainService
    {
        private readonly IDeliveryService _deliveryService;

        public OrderDomainService(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        public decimal GetTotal(Order order)
        {
            var totalPrice = order.Items.Sum(x => x.Product.Weight);

            if (totalPrice < 1000)
            {
                var totalWeight = order.Items.Sum(x => x.Product.Weight);
                totalPrice += (float)_deliveryService.CalculateDeliveryCosts(totalWeight);
            }

            return (decimal)totalPrice;
        }
    }
}