using GNUCannabis.Models;

namespace GNUCannabis.DTOs
{
    public class CultivoDto
    {
        public int IdCultivo { get; set; }
        public string Nombre { get; set; } = null!;
        public string? TipoCultivo { get; set; }
    }

    public class CultivoCreateUpdateDto
    {
        public string Nombre { get; set; } = null!;
        public int idTipoCultivo { get; set; }
    }
}
