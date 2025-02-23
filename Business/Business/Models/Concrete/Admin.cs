using System.ComponentModel.DataAnnotations;

namespace Business.Models.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminUsername { get; set; } // Kullanıcı adı
        public string AdminPasswordHash { get; set; } // Şifre (hashlenmiş)
        public DateTime AdminCreatedDate { get; set; } = DateTime.Parse(DateTime.Now.ToShortDateString());
    }
}
