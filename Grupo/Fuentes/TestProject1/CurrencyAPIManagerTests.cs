using Servidor.AccesoAPIs.CurrencyAPI;
using Servidor.Dominio;
using Servidor.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class CurrencyAPIManagerTests
    {
        private readonly CurrencyAPIManager _currencyAPIManager;

        public CurrencyAPIManagerTests()
        {
            _currencyAPIManager = new CurrencyAPIManager();
        }

        [Fact]
        public void GetMoneda_ReturnsValidMoneda()
        {
            // Arrange
            string codigoMoneda = "EUR";

            // Act
            Moneda moneda = _currencyAPIManager.GetMoneda(codigoMoneda);

            // Assert
            Assert.NotNull(moneda);
            Assert.Equal(codigoMoneda, moneda.Codigo);
            // Agregar más aserciones según la estructura esperada de Moneda
        }

        [Fact]
        public void GetCotizacion_ReturnsValidCotizacionDTO()
        {
            // Arrange
            string codigoMoneda = "USD";
            string codigoMonedaBase = "EUR";

            // Act
            CotizacionDTO cotizacionDTO = _currencyAPIManager.GetCotizacion(codigoMoneda, codigoMonedaBase);

            // Assert
            Assert.NotNull(cotizacionDTO);
            Assert.Equal(codigoMoneda, cotizacionDTO.Moneda);
            Assert.Equal(codigoMonedaBase, cotizacionDTO.MonedaBase);
            // Agregar más aserciones según la estructura esperada de CotizacionDTO
        }

        [Fact]
        public void GetHistorico_ReturnsValidCotizacionDTO()
        {
            // Arrange
            string codigoMoneda = "USD";
            string codigoMonedaBase = "EUR";
            string fecha = "2024-03-07"; // Ajustar según disponibilidad de datos históricos

            // Act
            CotizacionDTO cotizacionDTO = _currencyAPIManager.GetHistorico(codigoMoneda, codigoMonedaBase, fecha);

            // Assert
            Assert.NotNull(cotizacionDTO);
            Assert.Equal(codigoMoneda, cotizacionDTO.Moneda);
            Assert.Equal(codigoMonedaBase, cotizacionDTO.MonedaBase);
            // Agregar más aserciones según la estructura esperada de CotizacionDTO
        }
    }
}
