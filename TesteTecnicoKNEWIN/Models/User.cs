using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

namespace TesteTecnicoKNEWIN.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        [ForeignKey("UserId")]
        public ICollection<Post>? Posts { get; set; }
    }
}
