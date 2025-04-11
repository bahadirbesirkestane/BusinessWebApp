using Business.BusinessLayer.Abstract;
using Business.DataAccessLayer.Context;
using Business.EntityLayer.Concrete;
using Business.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly BusinessDbContext _context;


        public CategoryList(BusinessDbContext context,ICategoryService categoryService, IProductService productService)
        {
            _context = context;
            _categoryService = categoryService;
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            
            var categoryProductCounts = _context.Categories
                .Select(c => new CategoryProductCountViewModel
                {
                    CategoryName = c.CategoryName,
                    ProductCount = c.Products.Count()
                })
                .ToList();        

            return View(categoryProductCounts);
        }
    }
}
