using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sprint2.Models
{
    public class ResultadoIa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_resultadoIa { get; set; }
        public String Tipo_analise { get; set; }
        public String Detalhes { get; set; }
    }
}
