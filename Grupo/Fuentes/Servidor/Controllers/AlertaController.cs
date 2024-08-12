using Microsoft.AspNetCore.Mvc;
using Servidor.Datos.Repositorios;
using Servidor.DTO;
using Servidor.Services.IService;

namespace Servidor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAlertaService _alertaService;

        public AlertaController(IUnitOfWork unitOfWork, IAlertaService alertaService)
        {
            _unitOfWork = unitOfWork;
            _alertaService = alertaService;
        }

        [HttpPost]
        public async Task<IActionResult> ConfigurarOActualizarAlerta(AlertaDTO alerta)
        {
            try
            {
                var usuarioExistente = await _unitOfWork.UsuarioRepository.ObtenerUnicoAsync(u => u.Email == alerta.EmailUsuario);
                if (usuarioExistente == null)
                {
                    return NotFound(new { message = "Usuario no encontrado." });
                }
                var alertaExistente = await _unitOfWork.AlertaRepository.ObtenerUnicoAsync(u => u.UsuarioId == usuarioExistente.Id);
                if (alertaExistente != null)
                {
                    Console.WriteLine("Alerta existente, actualizando");
                    await _alertaService.ActualizarAlerta(alerta, usuarioExistente);
                }
                else
                {
                    Console.WriteLine("Alerta no encontrada, creando una nueva");
                    await _alertaService.CrearAlerta(alerta);
                }
                return Ok(new { message = "Operación completada con éxito." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la creación o actualización del usuario: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error al procesar la solicitud.", error = ex.Message });
            }
        }
    }
}