using Business.EntityLayer.Concrete;

namespace Business.Models.ViewModel
{
    public class ProductListViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
