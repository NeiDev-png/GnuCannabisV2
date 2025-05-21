namespace GNUCannabis.DTOs
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string? Persona { get; set; }
        public string Correo { get; set; } = null!;
        public string? Rol { get; set; }
        public bool Estado { get; set; }
    }
}
