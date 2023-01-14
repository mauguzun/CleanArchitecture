using AutoMapper;
using DataAccess.Interfaces;
using Entities.Models;
using MediatR;
using Mobile.UseCases.Orders.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace Mobile.UseCases.Orders.Commands.Create
{
    public class CreateOrderCommandHanlder : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;

        public CreateOrderCommandHanlder(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var order = _mapper.Map<Order>(request.Dto);
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChagesAsync();

            return order.Id;

        }
    }
}
