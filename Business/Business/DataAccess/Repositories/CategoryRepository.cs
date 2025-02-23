using Business.Context;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;
using System.Linq.Expressions;

namespace Business.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryDAL
    {
        private readonly BusinessDbContext _context;

        public CategoryRepository(BusinessDbContext context)
        {
            _context = context;
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
