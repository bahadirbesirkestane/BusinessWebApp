using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Models.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string CustomerName { get; set; } // Müşteri Adı
        public string CustomerEmail { get; set; } // E-posta
        public string? CustomerPhone { get; set; } // Telefon (opsiyonel)
        public string CustomerMessage { get; set; } // Müşteri mesajı
        public DateTime MessageCreatedDate { get; set; } = DateTime.Parse(DateTime.Now.ToShortDateString()); // Talep oluşturulma tarihi
        public bool MessageIsAnswered { get; set; } = false; // Yanıtlandı mı?

        // Hangi ürüne ait olduğunun takibi
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
