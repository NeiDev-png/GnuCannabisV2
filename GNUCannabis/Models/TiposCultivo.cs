using System;
using System.Collections.Generic;

namespace GNUCannabis.Models;

public partial class TiposCultivo
{
    public int IdTipoCultivo { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Cultivo> Cultivos { get; set; } = new List<Cultivo>();
}
