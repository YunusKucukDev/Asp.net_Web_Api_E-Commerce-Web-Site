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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.OrderingId= command.OrderingId;
            values.ProductPrice=command.ProductPrice;
            values.ProducTotalPrice= command.ProducTotalPrice;
            values.ProductName= command.ProductName;
            values.ProductId= command.ProductId;
            values.ProductAmount = command.ProductAmount;
            await _repository.UpdateAsync(values);
        }
    }
}
