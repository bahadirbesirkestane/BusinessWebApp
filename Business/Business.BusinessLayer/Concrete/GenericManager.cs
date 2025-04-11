using Business.BusinessLayer.Abstract;
using Business.DataAccessLayer.Abstact;
using Business.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDAL<T> _repository;

        public GenericManager(IGenericDAL<T> repository)
        {
            _repository = repository;
        }

        public void AddT(T t)
        {
            _repository.Insert(t);
        }

        public List<T> GetList()
        {
            return _repository.GetAll();
        }

        public void RemoveT(T t)
        {
            _repository.Delete(t);
        }

        public T TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateT(T t)
        {
            _repository.Update(t);
        }
    }
}
