using Servidor.Datos.Repositorios.IRepositorios;
using Servidor.Dominio;

namespace Servidor.Datos.Repositorios
{
    public class AlertaRepository : Repository<Alerta>, IAlertaRepository
    {
        public AlertaRepository(MonedaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
