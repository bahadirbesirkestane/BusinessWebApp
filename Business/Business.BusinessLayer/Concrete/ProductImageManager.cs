using Business.BusinessLayer.Abstract;
using Business.DataAccessLayer.Abstact;
using Business.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.Concrete
{
    public class ProductImageManager : GenericManager<ProductImage>, IProductImageService
    {
        private readonly IProductImageDAL _productImageDal;
        public ProductImageManager(IGenericDAL<ProductImage> repository, IProductImageDAL productImageDal) : base(repository)
        {
            _productImageDal = productImageDal;
        }

        public List<ProductImage> GetImagesWithProduct(int productId)
        {
            return _productImageDal.GetImagesWithProductDal(productId);
        }
    }
}
