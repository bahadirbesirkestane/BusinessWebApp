using System.ComponentModel.DataAnnotations;

namespace Business.Models.Concrete
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }
        public string PageTitle { get; set; } // Sayfa Başlığı
        public string PageContent { get; set; } // Sayfa İçeriği
        public string PageType { get; set; } // Sayfa Türü (Hakkımızda, İletişim vb.)
        public bool PageStatus { get; set; }
    }
}
