using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Order.Application.Features.CQRS.Results.OrderDetailResult;
using Udemy.Order.Application.Intarfaces;
using Udemy.Order.Domain.Entities;

namespace Udemy.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryCommandHandler
    {

        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailId = x.OrderDetailId,
                OrderingId = x.OrderingId,
                PrdocutAmount = x.ProductAmount,
                ProductName = x.ProductName,
                ProductId = x.ProductId,
                ProducTotalPrice = x.ProducTotalPrice,
                ProductPrice = x.ProductPrice
            }).ToList();

        }
    }
}
