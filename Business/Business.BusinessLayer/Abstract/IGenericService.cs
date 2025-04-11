using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
