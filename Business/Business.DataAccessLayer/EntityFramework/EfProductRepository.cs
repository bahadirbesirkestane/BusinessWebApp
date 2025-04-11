using Business.DataAccessLayer.Abstact;
using Business.DataAccessLayer.Context;
using Business.DataAccessLayer.Repositories;
using Business.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataAccessLayer.EntityFramework
{
    public class EfProductRepository : GenericRepository<Product>, IProductDAL
    {
        private readonly BusinessDbContext _context;
        public EfProductRepository(BusinessDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetListWithCategory()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }
    }
}
