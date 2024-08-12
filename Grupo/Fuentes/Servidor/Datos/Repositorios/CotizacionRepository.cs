using Microsoft.EntityFrameworkCore;
using Servidor.Datos.Repositorios.IRepositorios;
using Servidor.Dominio;

namespace Servidor.Datos.Repositorios
{
    public class CotizacionRepository : Repository<Cotizacion>, ICotizacionRepository
    {
        public CotizacionRepository(MonedaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cotizacion?> ObtenerUltimaCotizacionPorFecha(int monedaBase, int moneda, DateTime fecha)
        {

            try
            {
                var cotizacion = await _dbContext.Cotizaciones
                    .Where(c => c.MonedaBaseId == monedaBase && c.MonedaId == moneda && c.FechaHora.Date == fecha.Date)
                    .OrderByDescending(c => c.FechaHora)
                    .FirstOrDefaultAsync();
                return cotizacion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error al obtener la cotización: {ex.Message}");
                throw;
            }
        }

        public async Task<Cotizacion?> ObtenerUltimaCotizacion(int idMonedaBase, int idMoneda)
        {
            return await _dbContext.Cotizaciones
                .Where(c => c.MonedaBaseId == idMonedaBase && c.MonedaId == idMoneda)
                .OrderByDescending(c => c.FechaHora)
                .FirstOrDefaultAsync();
        }
    }
}
