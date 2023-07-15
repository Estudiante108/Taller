using System;
using System.Collections.Generic;

namespace Integracion.Models;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Clave { get; set; }

    public Guid? IdRol { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
