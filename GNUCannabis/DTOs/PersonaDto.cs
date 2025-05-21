namespace GNUCannabis.DTOs
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = null!;
    }
}
