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
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IProductDAL _productDAL;
        public ProductManager(IGenericDAL<Product> repository,IProductDAL productDAL) : base(repository)
        {
            _productDAL = productDAL;
        }

        public List<Product> GetProductListWithCategory()
        {
            return _productDAL.GetListWithCategory();
        }

    }
}
