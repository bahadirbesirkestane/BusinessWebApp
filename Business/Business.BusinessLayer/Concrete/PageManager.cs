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
    public class PageManager : GenericManager<Page>, IPageService
    {
        private readonly IPageDAL _pageDAL;
        public PageManager(IGenericDAL<Page> repository,IPageDAL pageDAL) : base(repository)
        {
            _pageDAL = pageDAL;
        }

        public Page GetPageByName(string pageName)
        {
            return _pageDAL.GetPageByNameDAL(pageName);
        }
    }
}
