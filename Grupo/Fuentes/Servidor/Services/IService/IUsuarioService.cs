using Servidor.Dominio;

namespace Servidor.Services.IService
{
    public interface IUsuarioService
    {
        Task<Moneda> ObtenerMonedaUsuarioAsync(int idUsuario);

        Task<Usuario?> ObtenerUsuarioPorEmailAsync(string emailUsuario);

        Task ActualizarUsuario(Usuario usuarioExistente, UsuarioDTO usuario);

        Task CrearUsuario(UsuarioDTO usuario);

        Task ActualizarTokenUsuario(string emailUsuario, string fcmToken);
    }
}
