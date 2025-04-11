using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.EntityLayer.Concrete
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
