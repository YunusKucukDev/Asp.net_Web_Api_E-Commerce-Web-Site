using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Order.Application.Features.CQRS.Results.OrderDetailResult
{
    public class GetOrderDetailByIdQueryResult
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int PrdocutAmount { get; set; }
        public decimal ProducTotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
