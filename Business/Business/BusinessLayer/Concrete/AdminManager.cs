using Business.BusinessLayer.Abstract;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;

namespace Business.BusinessLayer.Concrete
{
    public class AdminManager : GenericManager<Admin> ,IAdminService
    {
        public AdminManager(IGenericRepository<Admin> repository) : base(repository)
        {
        }

        
    }
}
