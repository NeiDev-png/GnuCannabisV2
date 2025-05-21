using System;
using System.Collections.Generic;

namespace GNUCannabis.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdPersona { get; set; }

    public string Correo { get; set; } = null!;

    public string ContrasenaHash { get; set; } = null!;

    public int IdRol { get; set; }

    public bool Estado { get; set; }

    public int? IdCultivo { get; set; }

    public virtual Cultivo? IdCultivoNavigation { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
