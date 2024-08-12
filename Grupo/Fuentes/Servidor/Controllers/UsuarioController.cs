using Microsoft.AspNetCore.Mvc;
using Servidor.Datos.Repositorios;
using Servidor.Dominio;
using Servidor.Services.IService;

namespace Servidor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUnitOfWork unitOfWork, IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearOActualizarUsuario(UsuarioDTO usuario)
        {
            try
            {
                Console.WriteLine("Comenzando la creación o actualización de usuario para el email");
                var usuarioExistente = await _unitOfWork.UsuarioRepository.ObtenerUnicoAsync(u => u.Email == usuario.Email);
                if (usuarioExistente != null)
                {
                    Console.WriteLine("Usuario existente encontrado, actualizando");
                    await _usuarioService.ActualizarUsuario(usuarioExistente, usuario);
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado, creando uno nuevo");
                    await _usuarioService.CrearUsuario(usuario);
                }
                Console.WriteLine("Operación de creación o actualización completada para el email");
                return Ok(new { message = "Operación completada con éxito." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la creación o actualización del usuario: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error al procesar la solicitud." , error = ex.Message});
            }
        }

    }
}