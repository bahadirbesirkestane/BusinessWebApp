using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Business.Models.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        public List<Product> Products { get; set; }
    }
}
