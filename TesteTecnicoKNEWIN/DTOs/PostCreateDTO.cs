using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoKNEWIN.DTOs
{
    public class PostCreateDTO
    {
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Título vazio")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Post sem conteúdo")]
        public string Content { get; set; }
    }
}
