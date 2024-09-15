using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sprint2.Models
{
    public class InteracaoCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_interacao { get; set; }
        public int Id_cliente { get; set; }
        public DateTime Data_interacao { get; set; }
        
        [RegularExpression("^(visita_site|interacao_social|compra_site|envio_email|clique_anuncio)$", ErrorMessage = "Tipo deve ser visita_site, interacao_social, compra_site, envio_email, clique_anuncio")]
        public String Tipo { get; set; }
        
        [RegularExpression("^(facebook|instagram|twitter|site|email)$", ErrorMessage = "Canal deve ser facebook, instagram, twitter, site, email")]
        public String Canal { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
