using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Business.Models.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Parse(DateTime.Now.ToShortDateString());
        public bool CommentStatus { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
