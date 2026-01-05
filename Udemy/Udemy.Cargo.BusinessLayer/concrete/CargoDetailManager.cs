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
    public class CargoDetailManager: IGenericService<CargoDetail>, ICargoDetailService
    {

        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public void TDelete(int id)
        {
            _cargoDetailDal.Delete(id);
        }

        public List<CargoDetail> TGetAll()
        {
             return _cargoDetailDal.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return _cargoDetailDal.GetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            _cargoDetailDal.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetailDal.Update(entity);
        }
    }
}
