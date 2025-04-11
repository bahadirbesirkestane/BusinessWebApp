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
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        ICommentDAL _commentDAL;
        public CommentManager(IGenericDAL<Comment> repository,ICommentDAL commentDAL) : base(repository)
        {
            _commentDAL = commentDAL;
        }

        public List<Comment> GetCommentsByProduct(int productId)
        {
            return _commentDAL.GetCommentsByProductDal(productId);
        }
    }
}
