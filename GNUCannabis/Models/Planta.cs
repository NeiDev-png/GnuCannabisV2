using System;
using System.Collections.Generic;

namespace GNUCannabis.Models;

public partial class Planta
{
    public int IdPlanta { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdCultivo { get; set; }

    public int IdTipoPlanta { get; set; }

    public int IdEstadoPlanta { get; set; }

    public virtual ICollection<HistorialPlanta> HistorialPlanta { get; set; } = new List<HistorialPlanta>();

    public virtual Cultivo IdCultivoNavigation { get; set; } = null!;

    public virtual EstadosPlanta IdEstadoPlantaNavigation { get; set; } = null!;

    public virtual TiposPlanta IdTipoPlantaNavigation { get; set; } = null!;
}
