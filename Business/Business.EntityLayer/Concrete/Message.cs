using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string CustomerName { get; set; } // Müşteri Adı
        public string CustomerEmail { get; set; } // E-posta
        public string? CustomerPhone { get; set; } // Telefon (opsiyonel)
        public string CustomerMessage { get; set; } // Müşteri mesajı
        public DateTime MessageCreatedDate { get; set; } = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));
        public bool MessageIsAnswered { get; set; } = false; // Yanıtlandı mı?
        public string? AdminReply { get; set; }

        // Hangi ürüne ait olduğunun takibi
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
