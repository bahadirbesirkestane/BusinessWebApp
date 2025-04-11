
using Business.BusinessLayer.Abstract;
using Business.BusinessLayer.ValidationRules;
using Business.DataAccessLayer.Context;
using Business.EntityLayer.Concrete;
using Business.Models.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Business.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductImageService _productImageService;
        private readonly BusinessDbContext _context;

        public ProductController(BusinessDbContext context, IProductService productService, ICategoryService categoryService, IProductImageService productImageService)
        {
            _context = context;
            _productService = productService;
            _categoryService = categoryService;
            _productImageService = productImageService;
        }

        public IActionResult Deneme(int page=1)
        {
            int pageSize = 9; // Her sayfada maksimum 9 ürün göster

            var products = _productService.GetProductListWithCategory() // Ürünleri veritabanından çek
                .OrderByDescending(p => p.ProductId) // Yeni eklenen ürünler önce gelsin
                .Skip((page - 1) * pageSize) // Sayfa numarasına göre ürünleri kaydır
                .Take(pageSize) // Sadece 9 ürünü al
                .ToList();


            int totalProducts = _productService.GetList().Count(); // Toplam ürün sayısı
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize); // Toplam sayfa sayısı
            ViewBag.CurrentPage = page; // Şu anki sayfa


            foreach (var item in products)
            {
                var productImages = _productImageService.GetImagesWithProduct(item.ProductId);

                if (productImages.Count != 0)
                {
                    item.Images = productImages;
                }

            }


            return View(products);
        }

        public IActionResult Menu(int? categoryId)
        {
            

            var categories = _categoryService.GetList();
            var products = _productService.GetList();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            var model = new ProductListViewModel
            {
                Categories = categories,
                Products = products
            };

            return View(model);

        }

        public IActionResult GetProductsByCategory(int? categoryId)
        {
            var products = _productService.GetProductListWithCategory();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            return PartialView("_ProductListPartial", products);
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 9; // Her sayfada maksimum 9 ürün göster

            var products = _productService.GetProductListWithCategory() // Ürünleri veritabanından çek
                .OrderByDescending(p => p.ProductId) // Yeni eklenen ürünler önce gelsin
                .Skip((page - 1) * pageSize) // Sayfa numarasına göre ürünleri kaydır
                .Take(pageSize) // Sadece 9 ürünü al
                .ToList();


            int totalProducts = _productService.GetList().Count(); // Toplam ürün sayısı
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize); // Toplam sayfa sayısı
            ViewBag.CurrentPage = page; // Şu anki sayfa


            foreach (var item in products)
            {
                var productImages = _productImageService.GetImagesWithProduct(item.ProductId);

                if (productImages.Count != 0)
                {
                    item.Images = productImages;
                }

            }


            return View(products);
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
            var value = _productService.TGetById(id);

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

        [HttpGet]
        public IActionResult AddProductImage(int id)
        {
            var product = _productService.TGetById(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = _productImageService.GetImagesWithProduct(id);

            if (model.Count != 0)
            {
                return View(model);
            }
            else
            {
                var model2 = new List<ProductImage>
                {
                    new ProductImage { ProductId = id,Product = product },
                };

                return View(model2);
            }

        }

        [HttpPost]
        public IActionResult AddProductImage(int productId, List<IFormFile> files)
        {
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    // Dosya adını benzersiz yapmak için GUID kullanıyoruz.
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Yeni resim ekleme
                    var productImage = new ProductImage
                    {
                        ProductId = productId,
                        ImageUrl = "/images/products/" + fileName
                    };

                    _productImageService.AddT(productImage);
                }
            }

            return RedirectToAction("AddProductImage", new { id = productId });

        }

        public IActionResult DeleteProductImage(int id)
        {
            var imageValue = _productImageService.TGetById(id);

            if (imageValue == null) { return NotFound(); }
            else
            {
                var productId = imageValue.ProductId;
                _productImageService.RemoveT(imageValue);

                return RedirectToAction("AddProductImage", new { id = productId });
            }


        }

        public IActionResult ProductSingle(int id)
        {
            var product = _productService.TGetById(id);
            var Images = _productImageService.GetImagesWithProduct(id);

            if (Images.Count != 0)
            {
                product.Images = Images;

            }


            // Next prev sayfa değerleri
            var previousProduct = _context.Products
                .Where(p => p.ProductId < id)
                .OrderByDescending(p => p.ProductId)
                .FirstOrDefault();

            // Sonraki Ürün
            var nextProduct = _context.Products
                .Where(p => p.ProductId > id)
                .OrderBy(p => p.ProductId)
                .FirstOrDefault();

            var pages = new PrevNextPageViewModel();

            pages.PreviousProduct = previousProduct;
            pages.NextProduct = nextProduct;

            ViewBag.PagesModel = pages;


            return View(product);
        }

    }
}
