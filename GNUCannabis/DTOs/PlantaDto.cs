namespace GNUCannabis.DTOs
{
    public class PlantaDto
    {
        public int IdPlanta { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Cultivo { get; set; }
        public string? TipoPlanta { get; set; }
        public string? EstadoPlanta { get; set; }
    }

    public class PlantaCreateUpdateDto
    {
        public string Nombre { get; set; } = null!;
        public int IdCultivo { get; set; }
        public int IdTipoPlanta { get; set; }
        public int IdEstadoPlanta { get; set; }
    }

}
