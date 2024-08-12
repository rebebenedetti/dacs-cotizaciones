using Servidor.Dominio;

namespace Servidor.Datos.Repositorios.IRepositorios
{
    public interface IPaisRepository : IRepository<Pais>
    {
        Task<Pais?> ObtenerPorCodigoAsync(string codigo);
    }
}
