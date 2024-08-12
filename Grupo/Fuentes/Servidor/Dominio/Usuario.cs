using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servidor.Dominio
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string? Token { get; set; }

        [ForeignKey("Pais")]
        public int PaisId { get; set; }

        public virtual Pais Pais { get; set; }
    }
}
