using Business.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataAccessLayer.Abstact
{
    public interface IProductImageDAL : IGenericDAL<ProductImage>
    {
        List<ProductImage> GetImagesWithProductDal(int productId);
    }
}
