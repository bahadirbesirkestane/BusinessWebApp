using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Models.Concrete
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; } // Fotoğraf URL'si
        public int ProductId { get; set; }
        public Product Product { get; set; } // İlişki
    }
}
