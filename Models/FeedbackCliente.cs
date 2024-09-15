using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sprint2.Models
{
    public class FeedbackCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_feedback { get; set; }
        
        public int Id_cliente { get; set; }

        public DateTime Data_feedback { get; set; }

        [MaxLength(300, ErrorMessage = "O Feedback deve conter no máximo 300 caracteres.")]
        public String Comentario { get; set; }

        [Range(1, 5, ErrorMessage = "A nota de avaliação deve estar entre 1 e 5.")]
        public int Avaliacao { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
