using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Cargo.BusinessLayer.absrtact;
using Udemy.Cargo.DataAccessLayer.Abstaction;
using Udemy.Cargo.EntityLayer.Concrete;

namespace Udemy.Cargo.BusinessLayer.concrete
{
    public class CargoCustomerManager : IGenericService<Cargocustomer> ,ICargoCustomerService
    {

        private readonly ICargoCustomerDal _cargocustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargocustomerDal)
        {
            _cargocustomerDal = cargocustomerDal;
        }

        public void TDelete(int id)
        {
            _cargocustomerDal.Delete(id);
        }

        public List<Cargocustomer> TGetAll()
        {
            return _cargocustomerDal.GetAll();
        }

        public Cargocustomer TGetById(int id)
        {
            return _cargocustomerDal.GetById(id);
        }

        public Cargocustomer TGetCargocustomerById(string Id)
        {
            return _cargocustomerDal.GetCargocustomerById(Id);
        }

        public void TInsert(Cargocustomer entity)
        {
            _cargocustomerDal.Insert(entity);
        }

        public void TUpdate(Cargocustomer entity)
        {
            _cargocustomerDal.Update(entity);
        }
    }
}
