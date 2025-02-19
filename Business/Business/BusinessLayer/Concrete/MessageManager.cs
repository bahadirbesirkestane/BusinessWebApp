using Business.BusinessLayer.Abstract;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;

namespace Business.BusinessLayer.Concrete
{
    public class MessageManager : GenericManager<Message>, IMessageService
    {
        public MessageManager(IGenericRepository<Message> repository) : base(repository)
        {
        }
    }
}
