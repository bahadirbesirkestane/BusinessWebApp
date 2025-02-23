using Business.Models.Concrete;
using System.Reflection.Metadata;

namespace Business.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetProductListWithCategory();

    }
}
