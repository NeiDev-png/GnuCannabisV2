using System;
using System.Collections.Generic;

namespace GNUCannabis.Models;

public partial class Cultivo
{
    public int IdCultivo { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdTipoCultivo { get; set; }

    public virtual TiposCultivo IdTipoCultivoNavigation { get; set; } = null!;

    public virtual ICollection<Planta> Planta { get; set; } = new List<Planta>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
