using Business.BusinessLayer.Abstract;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;

namespace Business.BusinessLayer.Concrete
{
    public class ProductImageManager : GenericManager<ProductImage>, IProductImageService
    {
        public ProductImageManager(IGenericRepository<ProductImage> repository) : base(repository)
        {
        }
    }
}
