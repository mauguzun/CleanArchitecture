namespace Delivery.Interfaces
{
    public interface IDeliveryService
    {
        decimal CalculateDeliveryCosts(float weight);

        Task<bool> IsDeliverdAsync(int orderId);
    } 
}