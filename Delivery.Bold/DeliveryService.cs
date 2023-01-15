using Delivery.Interfaces;

namespace Delivery.Bold
{
    public class DeliveryService : IDeliveryService
    {
        public decimal CalculateDeliveryCosts(float weight)
        {
            return (decimal)weight * 10;
        }

        public Task<bool> IsDeliverdAsync(int orderId) => Task.FromResult(true);
      
    }
}