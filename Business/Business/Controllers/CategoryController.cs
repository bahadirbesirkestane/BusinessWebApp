using Business.BusinessLayer.Abstract;
using Business.BusinessLayer.Concrete;
using Business.DataAccess.Abstact;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class CategoryController : Controller
    {
        //CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.GetList();

            return View();
        }
    }
}
