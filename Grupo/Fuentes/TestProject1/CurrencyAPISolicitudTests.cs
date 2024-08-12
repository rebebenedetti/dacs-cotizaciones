using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Servidor.AccesoAPIs.CurrencyAPI;
using System;
using System.Net.Http;
using Xunit;

namespace TestsProject1
{
    public class CurrencyAPISolicitudTests : IDisposable
    {
        private CurrencyAPISolicitud _currencyAPISolicitud;

        public CurrencyAPISolicitudTests()
        {
            _currencyAPISolicitud = new CurrencyAPISolicitud();
        }

        [Fact]
        public void ObtenerInfoMoneda_ReturnsValidJson()
        {
            // Arrange
            string codigoMoneda = "EUR";

            // Act
            string result = _currencyAPISolicitud.ObtenerInfoMoneda(codigoMoneda);
           
            // Assert
            AssertValidJsonObtenerInfoMoneda(result, codigoMoneda);
        }

        [Fact]
        public void ObtenerUltimoValor_ReturnsValidJson()
        {
            // Arrange
            string codigoMoneda = "USD";
            string codigoMonedaBase = "EUR";

            // Act
            string result = _currencyAPISolicitud.ObtenerUltimoValor(codigoMoneda, codigoMonedaBase);

            // Assert
            AssertValidJson(result, codigoMoneda);
        }

        [Fact]
        public void ObtenerHistorico_ReturnsValidJson()
       {
            // Arrange
            string codigoMoneda = "EUR";
            string codigoMonedaBase = "USD";
            string fecha = "2024-03-07";

            // Act
            string result = _currencyAPISolicitud.ObtenerHistorico(codigoMoneda, codigoMonedaBase, fecha);

            // Assert
            AssertValidJson(result, codigoMoneda);
        }

        private void AssertValidJsonObtenerInfoMoneda(string json, string codigoMoneda)
        {
            try
            {
                JObject jsonObject = JObject.Parse(json);
                Assert.NotNull(jsonObject["data"]);

                var data = jsonObject["data"];
                Assert.NotNull(data[codigoMoneda]);
                var moneda = data[codigoMoneda];
                Assert.NotNull(moneda["code"]);
                Assert.NotNull(moneda["name"]);
                Assert.NotNull(moneda["symbol"]);
                Assert.NotNull(moneda["symbol_native"]);
                Assert.NotNull(moneda["decimal_digits"]);
                Assert.NotNull(moneda["rounding"]);
                Assert.NotNull(moneda["type"]);
                Assert.NotNull(moneda["countries"]);
            }
            catch (JsonReaderException)
            {
                Assert.True(false, "El resultado no es un JSON válido.");
            }
        }


        private void AssertValidJson(string json, string codigoMoneda)
        {
            try
            {
                JObject jsonObject = JObject.Parse(json);

                // Verificar la presencia de "meta" y "data"
                Assert.NotNull(jsonObject["meta"]);
                Assert.NotNull(jsonObject["data"]);

                // Verificar la estructura dentro de "meta"
                var meta = jsonObject["meta"];
                Assert.NotNull(meta["last_updated_at"]);

                // Verificar la estructura dentro de "data" para el código de moneda dado
                var data = jsonObject["data"];
                Assert.NotNull(data[codigoMoneda]);
                var moneda = data[codigoMoneda];
                Assert.NotNull(moneda["code"]);
                Assert.NotNull(moneda["value"]);
            }
            catch (JsonReaderException)
            {
                Assert.True(false, "El resultado no es un JSON válido.");
            }
        }

        public void Dispose()
        {
            _currencyAPISolicitud.Dispose();
        }
    }
}
