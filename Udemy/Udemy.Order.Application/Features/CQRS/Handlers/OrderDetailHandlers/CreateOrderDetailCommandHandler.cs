using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Udemy.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Udemy.Order.Application.Intarfaces;
using Udemy.Order.Domain.Entities;

namespace Udemy.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductAmount=command.PrdocutAmount,
                OrderingId=command.OrderingId,
                ProductId=command.ProductId,
                ProductPrice=command.ProductPrice,
                ProducTotalPrice=command.ProducTotalPrice,
                ProductName = command.ProductName
            });
        }
    }
}
