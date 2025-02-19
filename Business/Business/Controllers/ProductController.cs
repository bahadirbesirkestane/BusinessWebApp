using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
