using Business.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetProductListWithCategory();
        //Product GetProductWithImages(int productId);
    }
}
