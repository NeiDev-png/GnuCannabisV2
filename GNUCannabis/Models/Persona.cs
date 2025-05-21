using System;
using System.Collections.Generic;

namespace GNUCannabis.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public int IdTipoDocumento { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public virtual TiposDocumento IdTipoDocumentoNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
