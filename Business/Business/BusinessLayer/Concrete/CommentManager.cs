using Business.BusinessLayer.Abstract;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;

namespace Business.BusinessLayer.Concrete
{
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        public CommentManager(IGenericRepository<Comment> repository) : base(repository)
        {
        }
    }
}
