using Servidor.Datos.Repositorios;
using Servidor.Dominio;
using Servidor.Services.IService;

namespace Servidor.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaisService _paisService;

        public UsuarioService(IUnitOfWork unitOfWork, IPaisService paisService)
        {
            _unitOfWork = unitOfWork;
            _paisService = paisService;
        }

        public async Task ActualizarUsuario(Usuario usuarioExistente, UsuarioDTO usuario)
        {
            try
            {
                Pais? paisActual = await _paisService.ObtenerPais(usuario.Latitud, usuario.Longitud);
                if (paisActual == null)
                {
                    Console.WriteLine("Pais no encontrado para el usuario, manteniendo PaisId existente");
                    throw new Exception("Pais no encontrado para el usuario.");
                }
                else if (paisActual.Id != usuarioExistente.PaisId)
                {
                    usuarioExistente.PaisId = paisActual.Id;
                    await _unitOfWork.UsuarioRepository.ActualizarAsync(usuarioExistente);
                    await _unitOfWork.CompletarAsync();
                }
                else
                {
                    usuarioExistente.Token = usuario.Token;
                    await _unitOfWork.UsuarioRepository.ActualizarAsync(usuarioExistente);
                    await _unitOfWork.CompletarAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el usuario: {ex.Message}");
                throw new Exception("Error al actualizar el usuario.", ex);
            }
        }

        public async Task CrearUsuario(UsuarioDTO usuario)
        {
            try
            {
                var pais = await _paisService.ObtenerPais(usuario.Latitud, usuario.Longitud);
                if (pais != null)
                {
                    var nuevoUsuario = new Usuario
                    {
                        Nombre = usuario.Nombre,
                        Email = usuario.Email,
                        PaisId = pais.Id,
                    };
                    await _unitOfWork.UsuarioRepository.InsertarAsync(nuevoUsuario);
                    await _unitOfWork.CompletarAsync();
                }
                else
                {
                    throw new Exception("Pais no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                throw new Exception("Error al crear el usuario.", ex);
            }
        }

        public async Task<Usuario?> ObtenerUsuarioPorEmailAsync(string email)
        {
            try
            {
                return await _unitOfWork.UsuarioRepository.ObtenerUnicoAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el usuario con email: {email}", ex);
            }
        }

        public async Task<Moneda> ObtenerMonedaUsuarioAsync(int idUsuario)
        {
            try
            {
                var usuario = await _unitOfWork.UsuarioRepository.ObtenerPorIdAsync(idUsuario);
                if (usuario == null)
                    return null;

                var pais = await _unitOfWork.PaisRepository.ObtenerPorIdAsync(usuario.PaisId);
                if (pais == null)
                    return null;

                var moneda = await _unitOfWork.MonedaRepository.ObtenerPorIdAsync(pais.MonedaId);
                if (moneda == null)
                    return null;

                return moneda;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el código de moneda para el usuario con ID: {idUsuario}", ex);
            }
        }

        public async Task ActualizarTokenUsuario(string emailUsuario, string fcmToken)
        {
            try
            {
                var usuario = await _unitOfWork.UsuarioRepository.ObtenerUnicoAsync(u => u.Email == emailUsuario);
                if (usuario != null)
                {
                    usuario.Token = fcmToken;
                    await _unitOfWork.UsuarioRepository.ActualizarAsync(usuario);
                    await _unitOfWork.CompletarAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el usuario: {ex.Message}");
                throw new Exception("Error al actualizar el usuario.", ex);
            }
        }
    }
}
