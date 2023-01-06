﻿using AutoMapper;
using DataAccess.Interface;
using DomainServices.Intefaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Orders.Dto;

namespace UseCases.Orders.Queries.GetOrderBy
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
