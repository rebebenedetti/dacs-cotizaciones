using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servidor.Dominio
{
    public class Cotizacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Valor { get; set; }

        public int MonedaId { get; set; }

        [ForeignKey("MonedaBase")]
        public int MonedaBaseId { get; set; }
        public virtual Moneda MonedaBase { get; set; }
    }
}
