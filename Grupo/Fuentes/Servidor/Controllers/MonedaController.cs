using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servidor.Datos;
using Servidor.Datos.Repositorios;

namespace Servidor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MonedaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var monedas = await _unitOfWork.MonedaRepository.ObtenerTodosAsync();
                    return Ok(monedas);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
