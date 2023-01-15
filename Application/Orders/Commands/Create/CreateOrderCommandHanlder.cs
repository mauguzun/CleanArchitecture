using AutoMapper;
using DataAccess.Interfaces;
using Email.Interfaces;
using Entities.Models;
using MediatR;
using Mobile.UseCases.Orders.Dto;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Interfaces;

namespace Mobile.UseCases.Orders.Commands.Create
{
    public class CreateOrderCommandHanlder : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;
        private readonly IBackgoundJobService _jobService;
        private readonly ICurrentUserService _userService;

        public CreateOrderCommandHanlder(IMapper mapper, IDbContext dbContext, IBackgoundJobService jobService, ICurrentUserService userService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _jobService = jobService;
            _userService = userService;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var order = _mapper.Map<Order>(request.Dto);
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChagesAsync();

            _jobService.Schedule<IEmailService>(email => email.SednAsync(_userService.Email, "crated", "new order "));
            return order.Id;

        }
    }
}
