using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sprint2.Models
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_login { get; set; }
        public String Usuario { get; set; }
        
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres.")]
        public String Senha { get; set; }
    }
}
