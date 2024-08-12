using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.AccesoAPIs.CurrencyAPI
{
    public class CurrencyAPISolicitud : IDisposable
    {
        private const string API_URL = "https://api.currencyapi.com/v3/";
        private const string API_KEY = "?apikey=cur_live_YlRxYqz2qDzlgRdMmZAzGr6CcCG2dByFXTiBxu6w";
        private HttpClient iHttpClient;

        /// <summary>
        /// Constructor de la clase CurrencyApiRequest.
        /// Inicializa una instancia de HttpClient y establece la configuración base para realizar las solicitudes a la API de Currency.
        /// </summary>
        public CurrencyAPISolicitud()
        {
            iHttpClient = new HttpClient();
            iHttpClient.BaseAddress = new Uri(API_URL);
            iHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        }

        /// <summary>
        /// Realiza una solicitud GET al endpoint de la API para obtener información sobre una moneda específica.
        /// </summary>
        /// <param name="pCodigoMoneda">El código de la moneda para la cual se desea obtener la información.</param>
        /// <returns>Una cadena que representa los datos de la moneda en formato JSON, o nulo si la solicitud no fue exitosa.</returns>
        public string ObtenerInfoMoneda(string pCodigoMoneda)
        {
            var parametros = $"currencies{API_KEY}&currencies={pCodigoMoneda}";
            return EjecutarSolicitud(parametros);
        }

        /// <summary>
        /// Realiza una solicitud GET al endpoint de la API para obtener los datos más recientes de intercambio de monedas.
        /// </summary>
        /// <param name="pCodigoMoneda">El código de la moneda para la cual se desea obtener la información.</param>
        /// <param name="pCodigoMonedaBase">El código de la moneda base con respecto a la cual se mostrarán los datos.</param>
        /// <returns>Una cadena que representa los datos de intercambio de monedas en formato JSON, o nulo si la solicitud no fue exitosa.</returns>
        public string ObtenerUltimoValor(string pCodigoMoneda, string pCodigoMonedaBase)
        {
            var parametros = $"latest{API_KEY}&currencies={pCodigoMoneda}&base_currency={pCodigoMonedaBase}";
            return EjecutarSolicitud(parametros);
        }

        /// <summary>
        /// Realiza una solicitud GET al endpoint de la API para obtener los datos históricos de intercambio de monedas para una fecha específica.
        /// </summary>
        /// <param name="pCodigoMoneda">El código de la moneda para la cual se desea obtener la información histórica.</param>
        /// <param name="pCodigoMonedaBase">El código de la moneda base con respecto a la cual se mostrarán los datos históricos.</param>
        /// <param name="pFecha">La fecha para la cual se desea obtener los datos históricos de intercambio de monedas (formato: AAAA-MM-DD).</param>
        /// <returns>Una cadena que representa los datos históricos de intercambio de monedas en formato JSON, o nulo si la solicitud no fue exitosa.</returns>
        public string ObtenerHistorico(string pCodigoMoneda, string pCodigoMonedaBase, string pFecha)
        {
            var parametros = $"historical{API_KEY}&currencies={pCodigoMoneda}&base_currency={pCodigoMonedaBase}&date={pFecha}";
            return EjecutarSolicitud(parametros);
        }

        /// <summary>
        /// Realiza una solicitud HTTP GET utilizando los parámetros especificados y devuelve el contenido de la respuesta como una cadena.
        /// </summary>
        /// <param name="parametros">Los parámetros para la solicitud HTTP.</param>
        /// <returns>El contenido de la respuesta como una cadena si la solicitud fue exitosa; de lo contrario, devuelve null.</returns>
        private string EjecutarSolicitud(string parametros)
        {
            var respuesta = iHttpClient.GetAsync(parametros).Result;

            if (respuesta.IsSuccessStatusCode)
            {
                return respuesta.Content.ReadAsStringAsync().Result;
            }
            return null;
        }

        /// <summary>
        /// Libera los recursos utilizados por la instancia de HttpClient.
        /// </summary>
        public void Dispose()
        {
            iHttpClient.Dispose();
        }

    }
}
