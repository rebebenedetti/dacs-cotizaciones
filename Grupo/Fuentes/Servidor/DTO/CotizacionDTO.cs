namespace Servidor.DTO
{
    public class CotizacionDTO
    {
        public string Moneda {  get; set; }
        public string MonedaBase { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
