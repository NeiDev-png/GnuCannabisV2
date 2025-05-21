using System;
using System.Collections.Generic;

namespace GNUCannabis.Models;

public partial class TiposDocumento
{
    public int IdTipoDocumento { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
