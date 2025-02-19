using Business.BusinessLayer.Abstract;
using Business.DataAccess.Abstact;

namespace Business.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericManager(IGenericRepository<T> repository)
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
