using Servidor.Dominio;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servidor.DTO
{
    public class AlertaDTO
    {
        public string Token { get; set; }
        public decimal Porcentaje { get; set; }
        public string EmailUsuario { get; set; }
        public string CodigoMoneda { get; set; }
    }
}
