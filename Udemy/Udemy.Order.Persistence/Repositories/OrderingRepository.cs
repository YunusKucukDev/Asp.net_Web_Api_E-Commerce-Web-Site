using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Order.Application.Intarfaces;
using Udemy.Order.Domain.Entities;
using Udemy.Order.Persistence.Contex;

namespace Udemy.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContex _contex;

        public OrderingRepository(OrderContex contex)
        {
            _contex = contex;
        }

        public List<Ordering> GetOrderingsByUserId(string id)
        {
            var values = _contex.Orderings.Where(x => x.UserId == id).ToList();
            return values;
        }
    }
}
