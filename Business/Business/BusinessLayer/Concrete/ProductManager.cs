using Business.BusinessLayer.Abstract;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;

namespace Business.BusinessLayer.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {

        private readonly IProductDAL _productDAL;

        public ProductManager(IGenericRepository<Product> repository,IProductDAL productDAL) : base(repository)
        {
            _productDAL=productDAL;
        }

        public List<Product> GetProductListWithCategory()
        {
            return _productDAL.GetListWithCategory();
        }
    }
}
