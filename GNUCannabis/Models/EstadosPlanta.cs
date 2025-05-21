using System;
using System.Collections.Generic;

namespace GNUCannabis.Models;

public partial class EstadosPlanta
{
    public int IdEstadoPlanta { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<Planta> Planta { get; set; } = new List<Planta>();
}
