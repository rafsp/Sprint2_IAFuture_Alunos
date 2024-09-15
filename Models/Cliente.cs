using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint2.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_cliente { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public DateTime Data_nascimento { get; set; }

        [MaxLength(11, ErrorMessage = "O CPF deve conter no máximo 11 caracteres.")]
        public String Cpf { get; set; }
        public String Telefone { get; set; }
        public ICollection<FeedbackCliente>? Feedbacks { get; set; }
        public ICollection<InteracaoCliente>? Interacoes { get; set; }

    }
}
