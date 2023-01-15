using DataAccess.Interfaces;
using Delivery.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile.UseCases.Orders.BackgroundJobs
{
    public class UpdateDeliveryStatusJob : IJob
    {
        private readonly IDbContext _dbContext;
        private readonly IDeliveryService _deliveryService;

        public UpdateDeliveryStatusJob(IDbContext dbContext, IDeliveryService deliveryService)
        {
            _dbContext = dbContext;
            _deliveryService = deliveryService;
        }

        public async Task ExecuteAsync()
        {
            var orders = await
                _dbContext.Orders.Where(x => x.Status == Entities.Enums.OrderStatus.Created).ToListAsync();

           var items =  orders.Select(x => new { Order = x, Task = _deliveryService.IsDeliverdAsync(x.Id) })
                .ToList();

            await Task.WhenAll(items.Select(x => x.Task));

            foreach (var item in items)
            {
                if(item.Task.Result)
                {
                    item.Order.Status = Entities.Enums.OrderStatus.Delivred;
                }
            }
            await _dbContext.SaveChagesAsync();
        }
    }
}
