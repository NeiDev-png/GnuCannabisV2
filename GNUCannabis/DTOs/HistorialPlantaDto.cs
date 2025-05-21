namespace GNUCannabis.DTOs
{
    public class HistorialPlantaDto
    {
        public int IdHistorial { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
