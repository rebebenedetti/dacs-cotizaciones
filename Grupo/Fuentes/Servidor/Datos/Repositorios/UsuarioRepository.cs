using Microsoft.EntityFrameworkCore;
using Servidor.Datos.Repositorios.IRepositorios;
using Servidor.Dominio;

namespace Servidor.Datos.Repositorios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        //private readonly IMonedaRepository _monedaRepository;

        public UsuarioRepository(MonedaDbContext dbContext) : base(dbContext)
        {
        }

        //public async Task<string> ObtenerMonedaUsuarioAsync(int idUsuario)
        //{
        //    try
        //    {
        //        var usuario = await _dbContext.Usuarios
        //            .Include(u => u.Pais) // Asegúrate de incluir la relación con el país
        //            .FirstOrDefaultAsync(u => u.Id == idUsuario);

        //        // Si no se encuentra el usuario, retornar null o manejar el caso según lo necesites
        //        if (usuario == null)
        //        {
        //            return null;
        //        }

        //        // Obtener el ID de la moneda asociada al país del usuario
        //        int idMoneda = usuario.Pais.MonedaId;

        //        // Buscar la moneda por su ID para obtener su código
        //        var moneda = await _monedaRepository.ObtenerPorIdAsync(idMoneda);

        //        // Si no se encuentra la moneda, retornar null o manejar el caso según lo necesites
        //        if (moneda == null)
        //        {
        //            return null;
        //        }
        //        return moneda.Codigo;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error al obtener el código de moneda para el usuario con ID: {idUsuario}", ex);
        //    }
        //}
    }
}
