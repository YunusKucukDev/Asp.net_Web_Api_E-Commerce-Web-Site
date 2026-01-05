using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Udemy.Order.Application.Intarfaces;
using Udemy.Order.Domain.Entities;

namespace Udemy.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler
        : IRequestHandler<CreateOrderingCommands, Unit>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderingCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                UserId = request.UserId,
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice
            });

            return Unit.Value;
        }
    }
}
