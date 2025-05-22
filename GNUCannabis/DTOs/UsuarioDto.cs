namespace GNUCannabis.DTOs
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string? Persona { get; set; }
        public string Correo { get; set; } = null!;
        public string? Rol { get; set; }
        public string? Cultivo { get; set; }
        public string? Estado { get; set; }
    }

    public class UsuarioCreateUpdateDto
    {
        public int IdPersona { get; set; }
        public string Correo { get; set; } = null!;
        public int IdRol { get; set; }
        public int IdCultivo { get; set; }
        public int Estado { get; set; }
        public string Contraseña { get; set; } = null!;
    }
}
