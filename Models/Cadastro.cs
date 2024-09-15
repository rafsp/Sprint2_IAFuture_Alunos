using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sprint2.Models
{
    public class Cadastro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_cadastro { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Endereco { get; set; }
        
        [Required(ErrorMessage = "Insira o CNPJ da empresa.")]
        public String Cnpj { get; set; }
    }
}
