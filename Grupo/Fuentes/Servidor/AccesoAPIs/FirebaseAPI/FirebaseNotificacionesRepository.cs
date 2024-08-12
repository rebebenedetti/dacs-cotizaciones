using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Servidor.DTO;
namespace Servidor.AccesoAPIs.FirebaseAPI

{
    public class FirebaseNotificacionesRepository : IFirebaseNotificacionesRepository
    {
        public async Task<bool> EnviarNotificacionPush(MensajeDto message)
        {
            try
            {
                FirebaseApp defaultApp = FirebaseApp.DefaultInstance;
                var pathToKey = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AccesoAPIs", "FirebaseAPI", "key.json");
                if (defaultApp == null)
                {
                    defaultApp = FirebaseApp.Create(new AppOptions()
                    {
                        Credential = GoogleCredential.FromFile(pathToKey),
                    });
                }
                Console.WriteLine(defaultApp.Name);

                FirebaseMessaging messaging = FirebaseMessaging.GetMessaging(defaultApp);
                string result = await messaging.SendAsync(new Message()
                {
                    Notification = new Notification
                    {
                        Title = message.Notificacion.Title,
                        Body = message.Notificacion.Body,
                    },
                    Token = message.TokenId,
                });
                Console.WriteLine(result); //projects/projectId/messages/0:messageId
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

