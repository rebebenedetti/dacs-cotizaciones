using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servidor.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Monedas",
                columns: new[] { "Id", "Codigo", "Nombre" },
                values: new object[,]
                {
                    { 1, "AED", "Dirham de los Emiratos Árabes Unidos" },
                    { 2, "AFN", "Afghani afgano" },
                    { 3, "ALL", "Lek albanés" },
                    { 4, "AMD", "Dram armenio" },
                    { 5, "ANG", "Florín antillano neerlandés" },
                    { 6, "AOA", "Kwanza angoleño" },
                    { 7, "ARS", "Peso argentino" },
                    { 8, "AUD", "Dólar australiano" },
                    { 9, "AWG", "Florín arubeño" },
                    { 10, "AZN", "Manat azerbaiyano" },
                    { 11, "BAM", "Marco convertible de Bosnia-Herzegovina" },
                    { 12, "BBD", "Dólar de Barbados" },
                    { 13, "BDT", "Taka bangladesí" },
                    { 14, "BGN", "Lev búlgaro" },
                    { 15, "BHD", "Dinar bahreiní" },
                    { 16, "BIF", "Franco burundés" },
                    { 17, "BMD", "Dólar de Bermudas" },
                    { 18, "BND", "Dólar de Brunei" },
                    { 19, "BOB", "Boliviano" },
                    { 20, "BRL", "Real brasileño" },
                    { 21, "BSD", "Dólar bahameño" },
                    { 22, "BTN", "Ngultrum butanés" },
                    { 23, "BWP", "Pula de Botsuana" },
                    { 24, "BYN", "Rublo bielorruso" },
                    { 25, "BZD", "Dólar beliceño" },
                    { 26, "CAD", "Dólar canadiense" },
                    { 27, "CDF", "Franco congoleño" },
                    { 28, "CHF", "Franco suizo" },
                    { 29, "CLF", "Unidad de Fomento" },
                    { 30, "CLP", "Peso chileno" },
                    { 31, "CNY", "Yuan chino" },
                    { 32, "COP", "Peso colombiano" },
                    { 33, "CRC", "Colón costarricense" },
                    { 34, "CUC", "Peso convertible cubano" },
                    { 35, "CUP", "Peso cubano" },
                    { 36, "CVE", "Escudo caboverdiano" },
                    { 37, "CZK", "Corona checa" },
                    { 38, "DJF", "Franco de Yibuti" },
                    { 39, "DKK", "Corona danesa" },
                    { 40, "DOP", "Peso dominicano" },
                    { 41, "DZD", "Dinar argelino" },
                    { 42, "EGP", "Libra egipcia" },
                    { 43, "ERN", "'Nakfa eritrea" },
                    { 44, "ETB", "Birr etíope" },
                    { 45, "EUR", "Euro" },
                    { 46, "FJD", "óDlar fiyiano" },
                    { 47, "FKP", "Libra de las Islas Malvinas" },
                    { 48, "GBP", "Libra esterlina británica" },
                    { 49, "GEL", "Lari georgiano" },
                    { 50, "GGP", "Libra de Guernsey" },
                    { 51, "GHS", "Cedi ghanés" },
                    { 52, "GIP", "Libra de Gibraltar" },
                    { 53, "GMD", "Dalasi gambiano" },
                    { 54, "GNF", "Franco guineano" },
                    { 55, "GTQ", "Quetzal guatemalteco" },
                    { 56, "GYD", "Dólar guyanés" },
                    { 57, "HKD", "Dólar de Hong Kong" },
                    { 58, "HNL", "Lempira hondureño" },
                    { 59, "HRK", "Kuna croata" },
                    { 60, "HTG", "Gourde haitiano" },
                    { 61, "HUF", "Forint húngaro" },
                    { 62, "IDR", "Rupia indonesia" },
                    { 63, "ILS", "Nuevo séquel israelí" },
                    { 64, "INR", "Rupia india" },
                    { 65, "IQD", "Dinar iraquí" },
                    { 66, "IRR", "Rial iraní" },
                    { 67, "ISK", "Corona islandesa" },
                    { 68, "JMD", "Dólar jamaiquino" },
                    { 69, "JOD", "Dinar jordano" },
                    { 70, "JPY", "Yen japonés" },
                    { 71, "KES", "Chelín keniano" },
                    { 72, "KGS", "Som kirguís" },
                    { 73, "KHR", "Riel camboyano" },
                    { 74, "KMF", "Franco comorense" },
                    { 75, "KPW", "Won norcoreano" },
                    { 76, "KRW", "Won surcoreano" },
                    { 77, "KWD", "Dinar kuwaití" },
                    { 78, "KYD", "Dólar de las Islas Caimán" },
                    { 79, "KZT", "Tenge kazajo" },
                    { 80, "LAK", "Kip laosiano" },
                    { 81, "LBP", "Libra libanesa" },
                    { 82, "LKR", "Rupia de Sri Lanka" },
                    { 83, "LRD", "Dólar liberiano" },
                    { 84, "LSL", "Loti de Lesoto" },
                    { 85, "LYD", "Dinar libio" },
                    { 86, "MAD", "Dirham marroquí" },
                    { 87, "MDL", "Leu moldavo" },
                    { 88, "MGA", "Ariary malgache" },
                    { 89, "MKD", "Denar macedonio" },
                    { 90, "MMK", "Kyat birmano" },
                    { 91, "MNT", "Tugrik mongol" },
                    { 92, "MOP", "Pataca de Macao" },
                    { 93, "MRO", "Uguiya" },
                    { 94, "MUR", "Rupia mauriciana" },
                    { 95, "MVR", "Rupia de Maldivas" },
                    { 96, "MWK", "Kwacha malauí" },
                    { 97, "MXN", "Peso mexicano" },
                    { 98, "MYR", "Ringgit malayo" },
                    { 99, "MZN", "Metical mozambiqueño" },
                    { 100, "NAD", "Dólar namibio" },
                    { 101, "NGN", "Naira nigeriano" },
                    { 102, "NIO", "Córdoba nicaragüense" },
                    { 103, "NOK", "Corona noruega" },
                    { 104, "NPR", "Rupia nepalí" },
                    { 105, "NZD", "Dólar neozelandés" },
                    { 106, "OMR", "Rial omaní" },
                    { 107, "PAB", "Balboa panameño" },
                    { 108, "PEN", "Nuevo sol peruano" },
                    { 109, "PGK", "Kina de Papúa Nueva Guinea" },
                    { 110, "PHP", "Peso filipino" },
                    { 111, "PKR", "Rupia pakistaní" },
                    { 112, "PLN", "Zloty polaco" },
                    { 113, "PYG", "Guaraní paraguayo" },
                    { 114, "QAR", "Riyal qatarí" },
                    { 115, "RON", "Leu rumano" },
                    { 116, "RSD", "Dinar serbio" },
                    { 117, "RUB", "Rublo ruso" },
                    { 118, "RWF", "Franco ruandés" },
                    { 119, "SAR", "Riyal saudí" },
                    { 120, "SBD", "Dólar de las Islas Salomón" },
                    { 121, "SCR", "Rupia de Seychelles" },
                    { 122, "SDG", "Libra sudanesa" },
                    { 123, "SEK", "Corona sueca" },
                    { 124, "SGD", "Dólar de Singapur" },
                    { 125, "SHP", "Libra de Santa Elena" },
                    { 126, "SLL", "Leone de Sierra Leona" },
                    { 127, "SOS", "Chelín somalí" },
                    { 128, "SRD", "Dólar surinamés" },
                    { 129, "STD", "Dobra de Santo Tomé y Príncipe" },
                    { 130, "SVC", "Colón salvadoreño" },
                    { 131, "SYP", "Libra siria" },
                    { 132, "SZL", "Lilangeni de Suazilandia" },
                    { 133, "THB", "Baht tailandés" },
                    { 134, "TJS", "Somoni tayiko" },
                    { 135, "TMT", "Manat turcomano" },
                    { 136, "TND", "Dinar tunecino" },
                    { 137, "TOP", "Paʻanga tongano" },
                    { 138, "TRY", "Lira turca" },
                    { 139, "TTD", "Dólar de Trinidad y Tobago" },
                    { 140, "TWD", "Nuevo dólar taiwanés" },
                    { 141, "TZS", "Chelín tanzano" },
                    { 142, "UAH", "Grivna ucraniana" },
                    { 143, "UGX", "Chelín ugandés" },
                    { 144, "USD", "Dólar estadounidense" },
                    { 145, "UYU", "Peso uruguayo" },
                    { 146, "UZS", "Som uzbeko" },
                    { 147, "VEF", "Bolívar venezolano" },
                    { 148, "VND", "Dong vietnamita" },
                    { 149, "VUV", "Vatu vanuatuense" },
                    { 150, "WST", "Samoano tala" },
                    { 151, "XAF", "Franco CFA BEAC" },
                    { 152, "XCD", "Dólar del Caribe Oriental" },
                    { 153, "XOF", "Franco CFA de África Occidental" },
                    { 154, "XPF", "Franco CFP" },
                    { 155, "YER", "Rial yemení" },
                    { 156, "ZAR", "Rand sudafricano" },
                    { 157, "ZMW", "Kwacha zambiano" },
                    { 158, "ZWL", "Dólar zimbabuense" },
                    { 159, "BTC", "Bitcoin" },
                    { 160, "ETH", "Ethereum" },
                    { 161, "BNB", "Binance" },
                    { 162, "XRP", "Ripple" },
                    { 163, "SOL", "Solana" },
                    { 164, "DOT", "Polkadot" },
                    { 165, "AVAX", "Avalanche" },
                    { 166, "MATIC", "Matic Token" },
                    { 167, "LTC", "Litecoin" },
                    { 168, "ADA", "Cardano" },
                    { 169, "USDT", "Tether" },
                    { 170, "USDC", "USD Coin" },
                    { 171, "DAI", "Dai" },
                    { 172, "ARB", "Arbitrum" },
                    { 173, "OP", "Optimism" },
                    { 174, "VES", "Bolívar venezolano" },
                    { 175, "STN", "Dobra de Santo Tomé y Príncipe" },
                    { 176, "MRU", "Uguiya mauritana" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Codigo", "MonedaId", "Nombre" },
                values: new object[,]
                {
                    { 1, "AE", 1, "Emiratos Árabes Unidos" },
                    { 2, "AF", 2, "Afganistán" },
                    { 3, "AL", 3, "Albania" },
                    { 4, "AM", 4, "Armenia" },
                    { 5, "CW", 5, "Curazao" },
                    { 6, "SX", 5, "San Martín" },
                    { 7, "AO", 6, "Angola" },
                    { 8, "AR", 7, "Argentina" },
                    { 9, "AU", 8, "Australia" },
                    { 10, "CC", 8, "Islas Cocos" },
                    { 11, "CX", 8, "Isla de Pascua" },
                    { 12, "HM", 8, "Islas Heard y McDonald" },
                    { 13, "KI", 8, "Kiribati" },
                    { 14, "NF", 8, "Isla Norfolk" },
                    { 15, "NR", 8, "Nauru" },
                    { 16, "TV", 8, "Tuvalu" },
                    { 17, "AW", 9, "Aruba" },
                    { 18, "AZ", 10, "Azerbaiyán" },
                    { 19, "BA", 11, "Bosnia y Herzegovina" },
                    { 20, "BB", 12, "Barbados" },
                    { 21, "BD", 13, "Bangladesh" },
                    { 22, "BG", 14, "Bulgaria" },
                    { 23, "BH", 15, "Baréin" },
                    { 24, "BI", 16, "Burundi" },
                    { 25, "BM", 17, "Bermuda" },
                    { 26, "BN", 18, "Brunei" },
                    { 27, "BO", 19, "Bolivia" },
                    { 28, "BR", 20, "Brasil" },
                    { 29, "BS", 21, "Bahamas" },
                    { 30, "BT", 22, "Bután" },
                    { 31, "BW", 23, "Botsuana" },
                    { 32, "ZW", 23, "Zimbabue" },
                    { 33, "BY", 24, "Bielorrusia" },
                    { 34, "BZ", 25, "Belice" },
                    { 35, "CA", 26, "Canadá" },
                    { 36, "CD", 27, "República Democrática del Congo" },
                    { 37, "CH", 28, "Suiza" },
                    { 38, "LI", 28, "Liechtenstein" },
                    { 39, "CL", 30, "Chile" },
                    { 40, "CN", 31, "China" },
                    { 41, "CO", 32, "Colombia" },
                    { 42, "CR", 33, "Costa Rica" },
                    { 43, "CU", 35, "Cuba" },
                    { 44, "CV", 36, "Cabo Verde" },
                    { 45, "CZ", 37, "República Checa" },
                    { 46, "DJ", 38, "Yibuti" },
                    { 47, "DK", 39, "Dinamarca" },
                    { 48, "FO", 39, "Islas Faroe" },
                    { 49, "GL", 39, "Groenlandia" },
                    { 50, "DO", 40, "República Dominicana" },
                    { 51, "DZ", 41, "Argelia" },
                    { 52, "EG", 42, "Egipto" },
                    { 53, "PS", 42, "Territorios Palestinos" },
                    { 54, "ER", 43, "Eritrea" },
                    { 55, "ET", 44, "Etiopía" },
                    { 56, "AD", 45, "Andorra" },
                    { 57, "AT", 45, "Austria" },
                    { 58, "AX", 45, "Åland" },
                    { 59, "BE", 45, "Bélgica" },
                    { 60, "BL", 45, "San Bartolomé" },
                    { 61, "CP", 45, "Clipperton" },
                    { 62, "CY", 45, "Chipre" },
                    { 63, "DE", 45, "Alemania" },
                    { 64, "EA", 45, "Ceuta y Melilla" },
                    { 65, "EE", 45, "Estonia" },
                    { 66, "ES", 45, "España" },
                    { 67, "FI", 45, "Finlandia" },
                    { 68, "FR", 45, "Francia" },
                    { 69, "FX", 45, "Francia metropolitana" },
                    { 70, "GF", 45, "Guayana Francesa" },
                    { 71, "GP", 45, "Guadalupe" },
                    { 72, "GR", 45, "Grecia" },
                    { 73, "IC", 45, "Islas Canarias" },
                    { 74, "IE", 45, "Irlanda" },
                    { 75, "IT", 45, "Italia" },
                    { 76, "LT", 45, "Lituania" },
                    { 77, "LU", 45, "Luxemburgo" },
                    { 78, "LV", 45, "Letonia" },
                    { 79, "MC", 45, "Mónaco" },
                    { 80, "ME", 45, "Montenegro" },
                    { 81, "MF", 45, "San Martín" },
                    { 82, "MQ", 45, "Martinica" },
                    { 83, "MT", 45, "Malta" },
                    { 84, "NL", 45, "Países Bajos" },
                    { 85, "PM", 45, "San Pedro y Miquelón" },
                    { 86, "PT", 45, "Portugal" },
                    { 87, "RE", 45, "Reunión" },
                    { 88, "SI", 45, "Eslovenia" },
                    { 89, "SK", 45, "Eslovaquia" },
                    { 90, "SM", 45, "San Marino" },
                    { 91, "TF", 45, "Territorios Australes y Antárticas Franceses" },
                    { 92, "VA", 45, "Ciudad del Vaticano" },
                    { 93, "XK", 45, "Kosovo" },
                    { 94, "YT", 45, "Mayotte" },
                    { 95, "FJ", 46, "Fiyi" },
                    { 96, "FK", 47, "Islas Malvinas" },
                    { 97, "GB", 48, "Reino Unido" },
                    { 98, "UK", 48, "Reino Unido" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 48);
        }
    }
}
