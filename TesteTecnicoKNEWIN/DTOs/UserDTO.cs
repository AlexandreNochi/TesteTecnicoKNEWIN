using System.ComponentModel.DataAnnotations;
using TesteTecnicoKNEWIN.Models;

namespace TesteTecnicoKNEWIN.DTOs
{
    public class UserDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome vazio")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email vazio")]
        public string Email { get; set; }
    }
}
