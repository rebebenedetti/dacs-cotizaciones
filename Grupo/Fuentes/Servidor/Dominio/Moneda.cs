using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servidor.Dominio
{
    public class Moneda
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Pais> Paises { get; set; }
        public virtual ICollection<Cotizacion> Cotizaciones { get; set; }
    }
}
