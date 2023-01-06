using AutoMapper;
using DataAccess.Interface;
using Domain.Entities;
using DomainServices.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application
{
    public class OrderService : IOrderService
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IOrderDomainService orderDomainService;

        public OrderService(IDbContext dbContext, IMapper mapper, IOrderDomainService orderDomainService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            this.orderDomainService = orderDomainService;
        }


        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _dbContext.Orders
                .AsNoTracking()
                .Include(x => x.Items).ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null) throw new EntityNotFoundException();

            var dto = _mapper.Map<OrderDto>(order);
            dto.Total = orderDomainService.GetTotal(order);

            return dto;
        }


        public async Task<int> CreateOrderAsync(CreateOroderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChagesAsync();

            return order.Id;
        }
    }
}
