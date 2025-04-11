using Business.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Business.ViewComponents.Comment
{
    public class CommentListByProduct : ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentListByProduct(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var value = _commentService.GetCommentsByProduct(productId);

            return View(value);
        }
    }
}
