
using Business.BusinessLayer.Abstract;
using Business.BusinessLayer.ValidationRules;
using Business.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Reflection.Metadata;

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
            //var values = _categoryService.GetList();

            return View();
        }

        public IActionResult CategoryList()
        {
            var values = _categoryService.GetList();

            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator valRules = new CategoryValidator();

            ValidationResult results = valRules.Validate(category);

            if (results.IsValid)
            {
                category.CategoryStatus = true;

                _categoryService.AddT(category);

                return RedirectToAction("CategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var categoryValue = _categoryService.TGetById(id);

            return View(categoryValue);

        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            CategoryValidator valRules = new CategoryValidator();

            ValidationResult results = valRules.Validate(category);

            var categoryValue = _categoryService.TGetById(category.CategoryId);


            if (results.IsValid)
            {
                categoryValue.CategoryName = category.CategoryName;
                categoryValue.CategoryDescription = category.CategoryDescription;
                categoryValue.CategoryStatus = category.CategoryStatus;

                _categoryService.UpdateT(categoryValue);

                return RedirectToAction("CategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(categoryValue);
            
        }

        public IActionResult DeleteCategory(int id)
        {
            var categoryValue = _categoryService.TGetById(id);
            _categoryService.RemoveT(categoryValue);

            return RedirectToAction("CategoryList");

        }


    }
}
