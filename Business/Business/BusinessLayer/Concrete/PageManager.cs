using Business.BusinessLayer.Abstract;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;

namespace Business.BusinessLayer.Concrete
{
    public class PageManager : GenericManager<Page>, IPageService
    {
        public PageManager(IGenericRepository<Page> repository) : base(repository)
        {
        }
    }
}
