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

        private readonly CargoContex _contex;

        public EfCargoCustomerDal(CargoContex contex) : base(contex)
        {
            _contex = contex;
        }

        public Cargocustomer GetCargocustomerById(string Id)
        {
            var values = _contex.Cargocustomers.Where(x => x.UserCustomerId== Id).FirstOrDefault();
            return values;
        }
    }
}
