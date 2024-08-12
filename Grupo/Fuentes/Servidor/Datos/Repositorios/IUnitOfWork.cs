using Servidor.Datos.Repositorios.IRepositorios;

namespace Servidor.Datos.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        IAlertaRepository AlertaRepository { get; }
        ICotizacionRepository CotizacionRepository { get; }
        IMonedaRepository MonedaRepository { get; }
        IPaisRepository PaisRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        Task<int> CompletarAsync();
    }
}
