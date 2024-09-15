using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sprint2.Models
{
    public class Conta 
    {
        [Key]
        public int Id_conta { get; set; }
        public int Id_cadastro { get; set; } 

        [ForeignKey("Id_cadastro")]
        public Cadastro DadosCadastro { get; set; }
    }
}
