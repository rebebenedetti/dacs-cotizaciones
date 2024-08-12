namespace Servidor.Dominio
{
    public class UsuarioDTO
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string? Token { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

    }
}
