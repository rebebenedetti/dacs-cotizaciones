using System.Net.Http;
using System.Net.Http.Headers;

namespace Servidor.AccesoAPIs.LocationIQAPI
{
    public class LocationIQAPISolicitud : IDisposable
    {
        private const string API_URL = "https://us1.locationiq.com/v1/reverse";
        private const string API_KEY = "?key=pk.b0642d21e59162af995f8eb1068d31d5";
        private HttpClient _httpClient;

        public LocationIQAPISolicitud()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(API_URL) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        }

        public async Task<string?> ObtenerPais(string pLatitud, string pLongitud)
        {
            var parametros = $"{API_KEY}&lat={pLatitud}&lon={pLongitud}&format=json";
            var respuesta = await _httpClient.GetAsync(parametros);

            if (respuesta.IsSuccessStatusCode)
            {
                return respuesta.Content.ReadAsStringAsync().Result;
            }
            return null;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
