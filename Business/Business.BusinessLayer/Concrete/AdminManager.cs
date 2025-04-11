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
    public class AdminManager : GenericManager<Admin>, IAdminService
    {
        public AdminManager(IGenericDAL<Admin> repository) : base(repository)
        {
        }
    }
}
