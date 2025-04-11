using Business.BusinessLayer.Abstract;
using Business.DataAccessLayer.Context;
using Business.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Business.ViewComponents.Product
{
    public class LatestAdditionProduct : ViewComponent
    {
        private readonly BusinessDbContext _context;
        private readonly IProductImageService _productImageService;

        public LatestAdditionProduct(BusinessDbContext context,IProductImageService productImageService)
        {
            _context = context;
            _productImageService = productImageService;
        }
        public IViewComponentResult Invoke()
        {
            var count = 3;



            var products= _context.Products
                        .OrderByDescending(p => p.ProductCreatedDate)
                        .Take(count)
                        .ToList();

            

            foreach (var item in products)
            {
                item.Images = _productImageService.GetImagesWithProduct(item.ProductId);
            }

            return View(products);
        }
    }
}
