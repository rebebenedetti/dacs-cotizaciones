using Servidor.Dominio;
using Servidor.DTO;
using System.Text.Json;

namespace Servidor.AccesoAPIs.CurrencyAPI
{
    public class CurrencyAPIManager
    {
        protected CurrencyAPISolicitud iSolicitud;

        public CurrencyAPIManager()
        {
            iSolicitud = new CurrencyAPISolicitud();
        }

        public Moneda GetMoneda(string pCodigoMoneda)
        {
            var jsonString = iSolicitud.ObtenerInfoMoneda(pCodigoMoneda);
            return DeserializarMoneda(jsonString);
        }

        public CotizacionDTO GetCotizacion(string pCodigoMoneda, string pCodigoMonedaBase)
        {
            var jsonString = iSolicitud.ObtenerUltimoValor(pCodigoMoneda, pCodigoMonedaBase);
            return DeserializarCotizacion(jsonString, pCodigoMoneda, pCodigoMonedaBase);
        }

        public CotizacionDTO GetHistorico(string pCodigoMoneda, string pCodigoMonedaBase, string pFecha)
        {
            var jsonString = iSolicitud.ObtenerHistorico(pCodigoMoneda, pCodigoMonedaBase, pFecha);
            return DeserializarCotizacion(jsonString, pCodigoMoneda, pCodigoMonedaBase);
        }

        private Moneda DeserializarMoneda(string jsonString)
        {
            if (jsonString == null)
                return null;

            var root = JsonDocument.Parse(jsonString).RootElement;
            if (!root.TryGetProperty("data", out var dataElement))
                return null;

            // Obtiene la primera propiedad dentro de "data", que debería ser la moneda
            var monedaElement = dataElement.EnumerateObject().FirstOrDefault().Value;
            if (monedaElement.ValueKind == JsonValueKind.Null)
                return null;

            return new Moneda
            {
                Codigo = monedaElement.GetProperty("code").GetString(),
                Nombre = monedaElement.GetProperty("name").GetString(),
            };
        }


        private CotizacionDTO DeserializarCotizacion(string jsonString, string codigoMoneda, string codigoMonedaBase)
        {
            if (jsonString == null)
                return null;

            var root = JsonDocument.Parse(jsonString).RootElement;
            if (!root.TryGetProperty("data", out var dataElement))
                return null;

            var valor = dataElement.GetProperty(codigoMoneda).GetProperty("value").GetSingle();
            var fechaString = root.GetProperty("meta").GetProperty("last_updated_at").GetString();
            var fecha = DateTime.Parse(fechaString, null, System.Globalization.DateTimeStyles.RoundtripKind);


            return new CotizacionDTO
            {
                Moneda = codigoMoneda,
                MonedaBase = codigoMonedaBase,
                Valor = (decimal)valor,
                FechaHora = fecha
            };
        }
    }

}
