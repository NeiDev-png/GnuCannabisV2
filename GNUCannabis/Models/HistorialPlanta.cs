using System;
using System.Collections.Generic;

namespace GNUCannabis.Models;

public partial class HistorialPlanta
{
    public int IdHistorial { get; set; }

    public int IdPlanta { get; set; }

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Planta IdPlantaNavigation { get; set; } = null!;
}
