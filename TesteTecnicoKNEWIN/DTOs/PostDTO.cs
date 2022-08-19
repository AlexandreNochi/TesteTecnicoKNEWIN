using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoKNEWIN.DTOs
{
    public class PostDTO
    {
        public int UserId { get; set; }

        public DateTime PublicationDate { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Título vazio")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Post sem conteúdo")]
        public string Content { get; set; }
    }
}
