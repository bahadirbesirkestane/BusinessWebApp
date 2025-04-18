﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; } // Ürün Adı
        public string ProductDescription { get; set; } // Açıklama
        public decimal ProductPrice { get; set; } // Fiyat
        public DateTime ProductCreatedDate { get; set; } = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));
        public bool ProductStatus { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Comment> Comments { get; set; }
        public List<ProductImage> Images { get; set; }
        public List<Message> Messages { get; set; }
    }
}
