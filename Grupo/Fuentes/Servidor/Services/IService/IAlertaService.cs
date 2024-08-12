using Servidor.Dominio;
using Servidor.DTO;

namespace Servidor.Services.IService
{
    public interface IAlertaService
    {
        Task VerificarAlertasAsync();
        Task CrearAlerta(AlertaDTO alerta);
        Task ActualizarAlerta(AlertaDTO alerta, Usuario Usuario);
    }
}
