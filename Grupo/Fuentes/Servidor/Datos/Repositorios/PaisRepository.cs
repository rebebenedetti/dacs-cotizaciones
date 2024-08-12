using Microsoft.EntityFrameworkCore;
using Servidor.Datos.Repositorios.IRepositorios;
using Servidor.Dominio;

namespace Servidor.Datos.Repositorios
{
    public class PaisRepository : Repository<Pais>, IPaisRepository
    {
        public PaisRepository(MonedaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Pais?> ObtenerPorCodigoAsync(string codigo)
    {
            try
            {
                var pais = await _dbContext.Paises.Where(p => p.Codigo == codigo).FirstOrDefaultAsync();
                return pais;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
