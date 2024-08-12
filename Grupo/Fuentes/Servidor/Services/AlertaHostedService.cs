using Servidor.Services.IService;

namespace Servidor.Services
{
    public class AlertaHostedService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;
        private readonly TimeSpan _horaEjecucion;

        public AlertaHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _horaEjecucion = new TimeSpan(18, 00, 0);
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var tiempoActual = DateTime.Now.TimeOfDay;
            var tiempoHastaEjecucion = _horaEjecucion > tiempoActual
                ? _horaEjecucion - tiempoActual
                : _horaEjecucion.Add(new TimeSpan(24, 0, 0)) - tiempoActual;

            _timer = new Timer(EjecutarAlertaService, null, tiempoHastaEjecucion, Timeout.InfiniteTimeSpan);

            return Task.CompletedTask;
        }

        private void EjecutarAlertaService(object state)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var alertaService = scope.ServiceProvider.GetRequiredService<IAlertaService>();
                alertaService.VerificarAlertasAsync().Wait();
            }

            _timer.Change(new TimeSpan(24, 0, 0), Timeout.InfiniteTimeSpan);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
