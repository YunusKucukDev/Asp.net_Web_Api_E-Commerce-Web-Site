using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Cargo.DataAccessLayer.Abstaction;
using Udemy.Cargo.DataAccessLayer.Concrete;

namespace Udemy.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

        private readonly CargoContex _contex;

        public GenericRepository(CargoContex contex)
        {
            _contex = contex;
        }

        public void Delete(int id)
        {
            var values = _contex.Set<T>().Find(id);
            _contex.Set<T>().Remove(values);
            _contex.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _contex.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _contex.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _contex.Set<T>().Add(entity);
            _contex.SaveChanges();
        }

        public void Update(T entity)
        {
            _contex.Set<T>().Update(entity);
            _contex.SaveChanges();
        }
    }
}
