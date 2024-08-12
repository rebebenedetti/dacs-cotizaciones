using Servidor.AccesoAPIs.CurrencyAPI;
using Servidor.AccesoAPIs.FirebaseAPI;
using Servidor.Datos.Repositorios;
using Servidor.Dominio;
using Servidor.DTO;
using Servidor.Services.IService;

namespace Servidor.Services
{
    public class AlertaService : IAlertaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CurrencyAPIManager _currencyAPIManager;
        private readonly ICotizacionService _cotizacionService;
        private readonly IUsuarioService _usuarioService;
        private readonly IFirebaseNotificacionesRepository _firebaseNotificacionesRepository;

        public AlertaService(
            IUnitOfWork unitOfWork,
            ICotizacionService cotizacionService,
            CurrencyAPIManager currencyAPIManager,
            IFirebaseNotificacionesRepository firebaseNotificacionesRepository,
            IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _cotizacionService = cotizacionService;
            _currencyAPIManager = currencyAPIManager;
            _firebaseNotificacionesRepository = firebaseNotificacionesRepository;
            _usuarioService = usuarioService;
        }

        public async Task ActualizarAlerta(AlertaDTO alerta, Usuario usuario)
        {
            try
            {
                Alerta? alertaUsuario = await _unitOfWork.AlertaRepository.ObtenerUnicoAsync(m => m.UsuarioId == usuario.Id);
                var moneda = await _unitOfWork.MonedaRepository.ObtenerUnicoAsync(m => m.Codigo == alerta.CodigoMoneda);

                if (alertaUsuario != null && moneda != null)
                {
                    // Solo actualizar si hay cambios
                    if (alertaUsuario.Porcentaje != alerta.Porcentaje || alertaUsuario.MonedaId != moneda.Id)
                    {
                        alertaUsuario.Porcentaje = alerta.Porcentaje;
                        alertaUsuario.MonedaId = moneda.Id;
                        await _unitOfWork.AlertaRepository.ActualizarAsync(alertaUsuario);
                        await _unitOfWork.CompletarAsync();
                    }

                    // Verificar y actualizar el token del usuario si ha cambiado
                    if (alerta.Token != usuario.Token)
                    {
                        await _usuarioService.ActualizarTokenUsuario(alerta.EmailUsuario, alerta.Token);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar alerta: {ex.Message}");
                throw new Exception("Error al actualizar alerta.", ex);
            }
        }

        public async Task CrearAlerta(AlertaDTO alerta)
        {
            try
            {
                var usuario = await _usuarioService.ObtenerUsuarioPorEmailAsync(alerta.EmailUsuario);
                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                var moneda = await _unitOfWork.MonedaRepository.ObtenerUnicoAsync(m => m.Codigo == alerta.CodigoMoneda);
                if (moneda == null)
                {
                    throw new Exception("Moneda no encontrada");
                }
                if (usuario != null && moneda!=null)
                {
                    await _usuarioService.ActualizarTokenUsuario(alerta.EmailUsuario, alerta.Token);
                    var nuevaAlerta = new Alerta
                    {
                        Porcentaje = alerta.Porcentaje,
                        UsuarioId = usuario.Id,
                        MonedaId = moneda.Id,
                    };
                    await _unitOfWork.AlertaRepository.InsertarAsync(nuevaAlerta);
                    await _unitOfWork.CompletarAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                throw new Exception("Error al crear el usuario.", ex);
            }
        }

        public async Task VerificarAlertasAsync()
        {
            var alertas = await _unitOfWork.AlertaRepository.ObtenerTodosAsync();
            foreach (var alerta in alertas)
            {
                var usuario = await _unitOfWork.UsuarioRepository.ObtenerUnicoAsync(u => u.Id == alerta.UsuarioId);
                if (usuario == null)
                {
                    Console.WriteLine("Error: Usuario no encontrado.");
                    continue; // Saltar a la siguiente alerta.
                }

                var monedaUsuario = await _usuarioService.ObtenerMonedaUsuarioAsync(usuario.Id);
                var monedaSeleccionada = await _unitOfWork.MonedaRepository.ObtenerUnicoAsync(m => m.Id == alerta.MonedaId);

                if (monedaUsuario == null || monedaSeleccionada == null)
                {
                    Console.WriteLine("Error: Moneda de usuario o moneda seleccionada no encontrada.");
                    continue; // Saltar a la siguiente alerta.
                }
                var fechaActual = DateTime.UtcNow.Date;
                var fechaAnterior = fechaActual.AddDays(-1);

                var cotizacionActual = await _cotizacionService.ObtenerUltimaCotizacionPorFechaAsync(monedaSeleccionada.Codigo, monedaUsuario, fechaActual);
                var cotizacionAnterior = await _cotizacionService.ObtenerUltimaCotizacionPorFechaAsync(monedaSeleccionada.Codigo, monedaUsuario, fechaAnterior);

                if (cotizacionActual != null && cotizacionAnterior != null)
                {
                    var variacionPorcentaje = ((cotizacionActual.Valor - cotizacionAnterior.Valor) / cotizacionAnterior.Valor) * 100;

                    if (variacionPorcentaje >= alerta.Porcentaje)
                    {
                        var mensaje = new MensajeDto
                        {
                            TokenId = alerta.Usuario.Token,
                            Notificacion = new NotificacionDto
                            {
                                Title = "Alerta Quote!",
                                Body = $"La cotización de {monedaSeleccionada.Nombre} ha aumentado un {variacionPorcentaje:F2}% en comparación con ayer."
                            }
                        };
                        await _firebaseNotificacionesRepository.EnviarNotificacionPush(mensaje);
                    }
                }
            }
        }
    }
}
