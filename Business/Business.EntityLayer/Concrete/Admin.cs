using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminUsername { get; set; } // Kullanıcı adı
        public string AdminPasswordHash { get; set; } // Şifre (hashlenmiş)
        public DateTime AdminCreatedDate { get; set; } = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));
    }
}
