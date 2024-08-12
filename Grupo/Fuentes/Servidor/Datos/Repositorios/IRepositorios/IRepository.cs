using System.Linq.Expressions;

namespace Servidor.Datos.Repositorios.IRepositorios
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ObtenerTodosAsync();
        Task<IEnumerable<TEntity>> ObtenerAsync(Expression<Func<TEntity, bool>> filtro);
        Task<TEntity?> ObtenerUnicoAsync(Expression<Func<TEntity, bool>> filtro);
        Task<TEntity> ObtenerPorIdAsync(object id);
        Task InsertarAsync(TEntity entidad);
        Task ActualizarAsync(TEntity entidad);
        Task EliminarAsync(object id);
    }
}
