using Newtonsoft.Json.Linq;
using Servidor.AccesoAPIs.CurrencyAPI;
using Servidor.Dominio;

namespace Servidor.AccesoAPIs.LocationIQAPI
{
    public class LocationIQAPIManager
    {
        protected LocationIQAPISolicitud iSolicitud;

        public LocationIQAPIManager()
        {
            iSolicitud = new LocationIQAPISolicitud();
        }

        public async Task<Pais?> ObtenerPais(string pLatitud, string pLongitud)
        {
            string resultado = await iSolicitud.ObtenerPais(pLatitud, pLongitud);

            if (string.IsNullOrEmpty(resultado))
                return null;

            JObject jsonObject = JObject.Parse(resultado);

            string country = (string)jsonObject["address"]["country"];
            string countryCode = (string)jsonObject["address"]["country_code"];

            return new Pais
            {
                Codigo = countryCode.ToUpper(),
                Nombre = country
            };
        }
    }
}
