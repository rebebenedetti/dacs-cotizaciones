using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servidor.Dominio
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Codigo { get; set; }

        [ForeignKey("Moneda")]
        public int MonedaId { get; set; }

        public virtual Moneda Moneda { get; set; }
    }
}
