using Servidor.Datos.Repositorios.IRepositorios;
using Servidor.Dominio;

namespace Servidor.Datos.Repositorios
{
    public class MonedaRepository : Repository<Moneda>, IMonedaRepository
    {
        public MonedaRepository(MonedaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
