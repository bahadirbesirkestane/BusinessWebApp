using Business.BusinessLayer.Abstract;
using Business.BusinessLayer.ValidationRules;
using Business.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment,int productId)
        {
            CommentValidator valRules= new CommentValidator();

            ValidationResult results = valRules.Validate(comment);

            if (results.IsValid)
            {
                _commentService.AddT(comment);
                return RedirectToAction("ProductSingle", "Product", new { id = productId }); // Başarılı sayfasına yönlendirme
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            @TempData["Error"] = "Yorumunuz iletilmedi.";
            ViewBag.Comment= comment;
            return RedirectToAction("ProductSingle", "Product", new { id = productId }); // Başarılı sayfasına yönlendirme

        }

    }
}
