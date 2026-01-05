using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Cargo.DataAccessLayer.Abstaction;
using Udemy.Cargo.DataAccessLayer.Concrete;
using Udemy.Cargo.DataAccessLayer.Repositories;
using Udemy.Cargo.EntityLayer.Concrete;

namespace Udemy.Cargo.DataAccessLayer.EntityFreamwork
{
    public class EfCargoCustomerDal : GenericRepository<Cargocustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContex contex) : base(contex)
        {
        }
    }
}
