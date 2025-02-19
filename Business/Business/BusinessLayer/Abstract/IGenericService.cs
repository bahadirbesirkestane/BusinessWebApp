namespace Business.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void AddT(T t);
        void RemoveT(T t);
        void UpdateT(T t);
        List<T> GetList();
        T TGetById(int id);
    }
}
