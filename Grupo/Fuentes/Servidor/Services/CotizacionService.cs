using Servidor.AccesoAPIs.CurrencyAPI;
using Servidor.Datos.Repositorios;
using Servidor.Dominio;
using Servidor.DTO;
using Servidor.Services.IService;

namespace Servidor.Services
{
    public class CotizacionService : ICotizacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CurrencyAPIManager _currencyAPIManager;

        public CotizacionService(IUnitOfWork unitOfWork, CurrencyAPIManager currencyAPIManager)
        {
            _unitOfWork = unitOfWork;
            _currencyAPIManager = currencyAPIManager;
        }

        public async Task<CotizacionDTO> ObtenerUltimaCotizacionPorFechaAsync(string codigoMonedaSeleccionada, Moneda monedaUsuario, DateTime fecha)
        {
            try
            {
                var moneda = await _unitOfWork.MonedaRepository.ObtenerUnicoAsync(m => m.Codigo == codigoMonedaSeleccionada);
                var cotizacionExistente = await _unitOfWork.CotizacionRepository.ObtenerUltimaCotizacionPorFecha(monedaUsuario.Id, moneda.Id, fecha);
                if (cotizacionExistente == null)
                {
                    // Si no existe, llamar a la API para obtener la cotización
                    var cotizacionDTO = _currencyAPIManager.GetCotizacion(codigoMonedaSeleccionada, monedaUsuario.Codigo);
                    var nuevaCotizacion = DtoACotizacion(cotizacionDTO, monedaUsuario.Id, moneda.Id);

                    // Registrar la cotización en la base de datos
                    await _unitOfWork.CotizacionRepository.InsertarAsync(nuevaCotizacion);
                    await _unitOfWork.CompletarAsync();

                    // Devolver la nueva cotización
                    return cotizacionDTO;
                }
                else
                {
                    return CotizacionADTO(cotizacionExistente, moneda.Codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la cotización.", ex);
            }
        }

        public async Task<List<CotizacionDTO>> ObtenerCotizacionesPorRangoDeFechasAsync(Moneda monedaUsuario, string codigoMonedaSeleccionada, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var cotizacionesDTO = new List<CotizacionDTO>();
                var moneda = await _unitOfWork.MonedaRepository.ObtenerUnicoAsync(m => m.Codigo == codigoMonedaSeleccionada);

                // Iterar sobre todas las fechas dentro del rango especificado
                for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
                {
                    // Obtener la última cotización para cada fecha dentro del rango
                    try
                    {
                        var cotizacionExistente = await _unitOfWork.CotizacionRepository.ObtenerUltimaCotizacionPorFecha(monedaUsuario.Id, moneda.Id, fecha);
                        if (cotizacionExistente == null)
                        {
                            // Si no existe, llamar a la API para obtener la cotización
                            var cotizacionDTO = _currencyAPIManager.GetHistorico(codigoMonedaSeleccionada, monedaUsuario.Codigo, fecha.ToString("yyyy-MM-dd"));
                            var nuevaCotizacion = DtoACotizacion(cotizacionDTO, monedaUsuario.Id, moneda.Id);

                            // Registrar la cotización en la base de datos
                            await _unitOfWork.CotizacionRepository.InsertarAsync(nuevaCotizacion);
                            await _unitOfWork.CompletarAsync();

                            // Devolver la nueva cotización
                            cotizacionesDTO.Add(cotizacionDTO);
                        }
                        else
                        {
                            cotizacionesDTO.Add(CotizacionADTO(cotizacionExistente, moneda.Codigo));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener la cotización.", ex);
                    }
                }

                return cotizacionesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las cotizaciones por rango de fechas.", ex);
            }
        }

        public Cotizacion DtoACotizacion(CotizacionDTO cotizacionDTO, int monedaBase, int moneda)
        {
            var nuevaCotizacion = new Cotizacion
            {
                MonedaBaseId = monedaBase,
                MonedaId = moneda,
                Valor = cotizacionDTO.Valor,
                FechaHora = cotizacionDTO.FechaHora,
            };

            return nuevaCotizacion;
        }

        public CotizacionDTO CotizacionADTO(Cotizacion cotizacion, string moneda)
        {
            var nuevaCotizacion = new CotizacionDTO
            {
                MonedaBase = cotizacion.MonedaBase.Codigo,
                Moneda = moneda,
                Valor = cotizacion.Valor,
                FechaHora = cotizacion.FechaHora,
            };

            return nuevaCotizacion;
        }
    }

}
