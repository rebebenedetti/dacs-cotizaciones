using Servidor.Dominio;

namespace Servidor.Services.IService
{
    public interface IPaisService
    {
        Task<Pais?> ObtenerPais( string latitud,  string longitud);
    }
}
