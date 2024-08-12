using Servidor.Dominio;

namespace Servidor.Datos.Repositorios.IRepositorios
{
    public interface ICotizacionRepository : IRepository<Cotizacion>
    {
        Task<Cotizacion?> ObtenerUltimaCotizacionPorFecha(int monedaBase, int moneda, DateTime fecha);

        Task<Cotizacion?> ObtenerUltimaCotizacion(int idMonedaBase, int idMoneda);
    }
}
