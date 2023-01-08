using AutoMapper;
using DataAccess.Interfaces;
using DomainServices.Intefaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mobile.UseCases.Orders.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace Mobile.UseCases.Orders.Queries.GetOrderBy
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;
        private readonly IOrderDomainService orderDomainService;

        public GetOrderByIdQueryHandler(IMapper mapper, IDbContext dbContext, IOrderDomainService orderDomainService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            this.orderDomainService = orderDomainService;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
            .AsNoTracking()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (order == null) throw new EntityNotFoundException();

            var dto = _mapper.Map<OrderDto>(order);
            dto.Total = orderDomainService.GetTotal(order);

            return dto;
        }
    }
}
