using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; } = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));
        public bool CommentStatus { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
