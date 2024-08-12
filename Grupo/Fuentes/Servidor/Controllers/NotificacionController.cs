using Microsoft.AspNetCore.Mvc;
using Servidor.AccesoAPIs.FirebaseAPI;
using Servidor.DTO;

namespace Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : Controller
    {
        //Solo para prueba, no lo usamos en la ui
        private readonly IFirebaseNotificacionesRepository _firebaseNotificacionesRepository;

        public NotificacionController(IFirebaseNotificacionesRepository firebaseNotificacionesRepository)
        {
            _firebaseNotificacionesRepository = firebaseNotificacionesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Enviar(MensajeDto mensaje)
        {
            bool resultado = await _firebaseNotificacionesRepository.EnviarNotificacionPush(mensaje);
            return resultado ? Ok() : BadRequest();
        }
    }
}
