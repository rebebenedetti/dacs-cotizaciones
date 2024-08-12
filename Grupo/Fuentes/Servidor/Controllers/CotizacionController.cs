using Microsoft.AspNetCore.Mvc;
using Servidor.DTO;
using Servidor.Services.IService;
using System.Globalization;

namespace Servidor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CotizacionController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ICotizacionService _cotizacionService;

        public CotizacionController(
            IUsuarioService usuarioService, ICotizacionService cotizacionService)
        {
            _usuarioService = usuarioService;
            _cotizacionService = cotizacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCotizacion(string emailUsuario, string codigoMoneda)
        {
            try
            {
                var usuario = await _usuarioService.ObtenerUsuarioPorEmailAsync(emailUsuario);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }
                var monedaUsuario = await _usuarioService.ObtenerMonedaUsuarioAsync(usuario.Id);
                if (monedaUsuario != null)
                {
                    var fechaHoraUtc = DateTime.Today.ToUniversalTime();
                    var cotizacion = await _cotizacionService.ObtenerUltimaCotizacionPorFechaAsync(codigoMoneda, monedaUsuario, fechaHoraUtc);
                    if (cotizacion != null)
                    {
                        return Ok(cotizacion);
                    }
                    else
                    {
                        return NotFound("La cotizacion no fue encontrada");
                    }
                }
                else
                {
                    return NotFound("No se encontró la moneda del usuario.");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("cotizaciones")]
        public async Task<IActionResult> GetCotizacionesPorRangoDeFechas(string emailUsuario, string codigoMoneda, string fechaInicio, string fechaFin)
        {
            try
            {
                var usuario = await _usuarioService.ObtenerUsuarioPorEmailAsync(emailUsuario);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }
                var monedaUsuario = await _usuarioService.ObtenerMonedaUsuarioAsync(usuario.Id);
                if (monedaUsuario != null)
                {
                    // Convertir las cadenas de fecha en objetos DateTime
                    var fechaInicioDateTime = DateTime.ParseExact(fechaInicio, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    var fechaInicioUTC = fechaInicioDateTime.ToUniversalTime();
                    var fechaFinDateTime = DateTime.ParseExact(fechaFin, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    var fechaFinUTC = fechaFinDateTime.ToUniversalTime();

                    // Obtener las cotizaciones por rango de fechas
                    var cotizaciones = await _cotizacionService.ObtenerCotizacionesPorRangoDeFechasAsync(monedaUsuario, codigoMoneda, fechaInicioUTC, fechaFinUTC);

                    if (cotizaciones.Any())
                    {
                        return Ok(cotizaciones);
                    }
                    else
                    {
                        return NotFound("No se encontraron cotizaciones para el rango de fechas especificado.");
                    }
                }
                else
                {
                    return NotFound("No se encontró la moneda del usuario.");
                }

            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

    }
}
