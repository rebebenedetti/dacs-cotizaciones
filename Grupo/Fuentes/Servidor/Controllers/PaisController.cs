using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servidor.AccesoAPIs.LocationIQAPI;
using Servidor.Datos;
using Servidor.Datos.Repositorios;

namespace Servidor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LocationIQAPIManager _locationIQAPIManager;

        public PaisController(IUnitOfWork unitOfWork, LocationIQAPIManager locationIQAPIManager)
        {
            _unitOfWork = unitOfWork;
            _locationIQAPIManager = locationIQAPIManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string latitud, string longitud)
        {
            try
            {
                var posiblePais = await _locationIQAPIManager.ObtenerPais(latitud, longitud);
                if (posiblePais != null)
                {
                    var pais = await _unitOfWork.PaisRepository.ObtenerPorCodigoAsync(posiblePais.Codigo);
                    if (pais != null)
                    {
                        return Ok(pais);
                    }
                    else
                    {
                        return NotFound("El país no se encontró en la base de datos.");
                    }
                }
                else
                {
                    return NotFound("No se encontró información para las coordenadas proporcionadas.");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
