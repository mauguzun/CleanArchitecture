﻿using AutoMapper;
using DataAccess.Interfaces;
using Delivery.Interfaces;
using DomainServices.Intefaces;
using Entities.Models;
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
        private readonly IDeliveryService _iDeliveryService;
        private readonly IDbContext _dbContext;
        private readonly IOrderDomainService _orderDomainService;

        public GetOrderByIdQueryHandler(IMapper mapper, IDeliveryService iDeliveryService, IDbContext dbContext, IOrderDomainService orderDomainService)
        {
            _mapper = mapper;
            _iDeliveryService = iDeliveryService;
            _dbContext = dbContext;
            _orderDomainService = orderDomainService;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
            .AsNoTracking()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (order == null) throw new EntityNotFoundException();

            var dto = _mapper.Map<OrderDto>(order);
            dto.Total = _orderDomainService.GetTotal(order, _iDeliveryService.CalculateDeliveryCosts);

            return dto;
        }
    }
}
