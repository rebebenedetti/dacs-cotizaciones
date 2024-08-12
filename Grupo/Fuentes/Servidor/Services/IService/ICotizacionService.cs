using Servidor.Dominio;
using Servidor.DTO;

namespace Servidor.Services.IService
{
    public interface ICotizacionService
    {
        Task<CotizacionDTO> ObtenerUltimaCotizacionPorFechaAsync(string codigoMonedaSeleccionada, Moneda monedaUsuario, DateTime fecha);
        Task<List<CotizacionDTO>> ObtenerCotizacionesPorRangoDeFechasAsync(Moneda monedaUsuario, string codigoMonedaSeleccionada, DateTime fechaInicio, DateTime fechaFin);
    }
}
