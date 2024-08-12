using Servidor.DTO;

namespace Servidor.AccesoAPIs.FirebaseAPI
{
    public interface IFirebaseNotificacionesRepository
    {
        public Task<bool> EnviarNotificacionPush(MensajeDto message);
    }
}
