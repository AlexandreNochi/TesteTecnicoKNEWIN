using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoKNEWIN.Models
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int IdAuthor { get; set; }

        public DateTime PublicationDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        public Post(int id, int idAuthor, string title, string content)
        {
            Id = id;
            IdAuthor = idAuthor;
            PublicationDate = DateTime.Now;
            Title = title;
            Content = content;
        }
    }
}
