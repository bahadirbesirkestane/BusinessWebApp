using Business.DataAccessLayer.Abstact;
using Business.DataAccessLayer.Context;
using Business.DataAccessLayer.Repositories;
using Business.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataAccessLayer.EntityFramework
{
    public class EfPageRepository : GenericRepository<Page>, IPageDAL
    {
        private readonly BusinessDbContext _context;

        public EfPageRepository(BusinessDbContext context) : base(context)
        {
            _context = context;
        }

        public Page GetPageByNameDAL(string pageName)
        {
            var value= _context.Pages.Where(x=>x.PageType==pageName).FirstOrDefault();
            return value;
        }
    }
}
