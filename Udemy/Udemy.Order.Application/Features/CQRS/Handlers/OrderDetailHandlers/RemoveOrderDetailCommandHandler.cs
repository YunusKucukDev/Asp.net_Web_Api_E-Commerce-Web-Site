using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Order.Application.Features.CQRS.Commands.AddressCommands;
using Udemy.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Udemy.Order.Application.Intarfaces;
using Udemy.Order.Domain.Entities;

namespace Udemy.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(values);
        }

        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            throw new NotImplementedException();
        }
    }
}
