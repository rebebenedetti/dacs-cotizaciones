using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Servidor.Datos.Repositorios.IRepositorios;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace Servidor.Datos.Repositorios
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MonedaDbContext _dbContext;

        public Repository(MonedaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> ObtenerTodosAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ObtenerAsync(Expression<Func<TEntity, bool>> filtro)
        {
            return await _dbContext.Set<TEntity>().Where(filtro).ToListAsync();
        }

        public async Task<TEntity?> ObtenerUnicoAsync(Expression<Func<TEntity, bool>> filtro)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(filtro);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener entidad única: {ex.Message}");
                throw ex;
            }
        }

        public async Task<TEntity> ObtenerPorIdAsync(object id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task InsertarAsync(TEntity entidad)
        {
            await _dbContext.Set<TEntity>().AddAsync(entidad);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ActualizarAsync(TEntity entidad)
        {
            _dbContext.Entry(entidad).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task EliminarAsync(object id)
        {
            var entidad = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entidad != null)
            {
                _dbContext.Set<TEntity>().Remove(entidad);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
