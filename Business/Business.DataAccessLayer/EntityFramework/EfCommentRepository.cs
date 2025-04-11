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
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDAL
    {
        private readonly BusinessDbContext _context;
        public EfCommentRepository(BusinessDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Comment> GetCommentsByProductDal(int productId)
        {
            return _context.Comments.Where(x=> x.ProductId == productId).Include(x=>x.Product).ToList();
        }
    }
}
