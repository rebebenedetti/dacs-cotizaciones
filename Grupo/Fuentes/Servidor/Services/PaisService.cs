using Servidor.AccesoAPIs.LocationIQAPI;
using Servidor.Datos.Repositorios;
using Servidor.Dominio;
using Servidor.Services.IService;

namespace Servidor.Services
{
    public class PaisService : IPaisService
    {
        private readonly LocationIQAPIManager _locationIQAPIManager;
        private readonly IUnitOfWork _unitOfWork;

        public PaisService(IUnitOfWork unitOfWork, LocationIQAPIManager locationIQAPIManager)
        {
            _locationIQAPIManager = locationIQAPIManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<Pais?> ObtenerPais(string latitud, string longitud)
        {
            var posiblePais = await _locationIQAPIManager.ObtenerPais(latitud, longitud);
            if (posiblePais != null)
            {
                var pais = await _unitOfWork.PaisRepository.ObtenerPorCodigoAsync(posiblePais.Codigo);
                if (pais == null)
                {
                    throw new Exception($"El país no fue encontrado en la base de datos.");
                }
                return pais;
            }
            else
            {
                throw new Exception("No se pudo determinar el país a partir de las coordenadas proporcionadas.");
            }
        }
    }
}
