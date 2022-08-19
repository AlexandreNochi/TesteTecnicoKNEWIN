using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoKNEWIN.Models
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime PublicationDate { get; private set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        public Post(int userId, string title, string content)
        {
            UserId = userId;
            PublicationDate = DateTime.Now;
            Title = title;
            Content = content;
        }

        public Post(int id, int userId, string title, string content)
        {
            Id = id;
            UserId = userId;
            PublicationDate = DateTime.Now;
            Title = title;
            Content = content;
        }
    }
}
