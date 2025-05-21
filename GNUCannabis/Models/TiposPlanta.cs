using System;
using System.Collections.Generic;

namespace GNUCannabis.Models;

public partial class TiposPlanta
{
    public int IdTipoPlanta { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Planta> Planta { get; set; } = new List<Planta>();
}
