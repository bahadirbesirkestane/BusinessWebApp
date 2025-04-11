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
    public class EfMessageRepository : GenericRepository<Message>, IMessageDAL
    {
        public EfMessageRepository(BusinessDbContext context) : base(context)
        {
        }
    }
}
