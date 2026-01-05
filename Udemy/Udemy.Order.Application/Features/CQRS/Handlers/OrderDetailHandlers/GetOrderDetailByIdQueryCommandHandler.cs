using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Udemy.Order.Application.Features.CQRS.Queries.AddressQueries;
using Udemy.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Udemy.Order.Application.Features.CQRS.Results.AddressResults;
using Udemy.Order.Application.Features.CQRS.Results.OrderDetailResult;
using Udemy.Order.Application.Intarfaces;
using Udemy.Order.Domain.Entities;

namespace Udemy.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                OrderingId = values.OrderingId,
                PrdocutAmount = values.ProductAmount,
                ProductName = values.ProductName,
                ProducTotalPrice = values.ProducTotalPrice,
                ProductPrice = values.ProductPrice,
                ProductId = values.ProductId

            };
        }

    }
}
