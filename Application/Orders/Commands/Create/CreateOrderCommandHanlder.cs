using AutoMapper;
using DataAccess.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Orders.Commands.Create
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
            var order = _mapper.Map<Domain.Entities.Order>(request.Dto);
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChagesAsync();

            return order.Id;

        }
    }
}
