using Business.Context;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.DataAccess.Repositories
{
    public class ProductRepository : IProductDAL
    {
        private readonly BusinessDbContext _context;

        public ProductRepository(BusinessDbContext context)
        {
            _context = context;
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetListWithCategory()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }

        public void Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
