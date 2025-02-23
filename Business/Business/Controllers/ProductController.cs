using Business.BusinessLayer.Abstract;
using Business.BusinessLayer.Concrete;
using Business.BusinessLayer.ValidationRules;
using Business.Models.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var values = _productService.GetProductListWithCategory();
            

            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.CategoryValue = _categoryService.GetCategorySelectList();
            

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ProductValidator valRules = new ProductValidator();

            ValidationResult results = valRules.Validate(product);

            if (results.IsValid)
            {
                _productService.AddT(product);

                return RedirectToAction("ProductList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            ViewBag.CategoryValue = _categoryService.GetCategorySelectList();

            return View();
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var value=_productService.TGetById(id);

            ViewBag.CategoryValue = _categoryService.GetCategorySelectList();

            return View(value);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            ProductValidator valRules = new ProductValidator();

            ValidationResult results = valRules.Validate(product);

            var productValue = _productService.TGetById(product.ProductId);


            if (results.IsValid)
            {
                productValue.ProductName = product.ProductName;
                productValue.ProductPrice = product.ProductPrice;
                productValue.CategoryId = product.CategoryId;
                productValue.ProductDescription = product.ProductDescription;
                productValue.ProductStatus = product.ProductStatus; 

                _productService.UpdateT(productValue);


                return RedirectToAction("ProductList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            ViewBag.CategoryValue = _categoryService.GetCategorySelectList();

            return View(productValue);
        }

        public IActionResult DeleteProduct(int id)
        {
            var productValue = _productService.TGetById(id);
            _productService.RemoveT(productValue);

            return RedirectToAction("ProductList");

        }

    }
}
