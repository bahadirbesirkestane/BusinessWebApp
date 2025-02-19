using Business.BusinessLayer.Abstract;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;

namespace Business.BusinessLayer.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        public ProductManager(IGenericRepository<Product> repository) : base(repository)
        {
        }
    }
}
