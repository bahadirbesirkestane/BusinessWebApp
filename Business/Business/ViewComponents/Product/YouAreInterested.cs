using Business.BusinessLayer.Abstract;
using Business.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Business.ViewComponents.Product
{
    public class YouAreInterested : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;

        public YouAreInterested(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var productList = _productService.GetList();
            //var ImageList = _productImageService.GetImagesWithProduct();

            var product=_productService.TGetById(productId);

            if (productList!=null && product != null) 
            {
                productList.Remove(product);

            }
            else
                return NotFound();


            productList=productList.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
   

            foreach (var item in productList)
            {
                var productImages = _productImageService.GetImagesWithProduct(item.ProductId);

                if (productImages.Count != 0)
                {
                    item.Images = productImages;
                }

            }


            return View(productList);
        }

        private IViewComponentResult NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
