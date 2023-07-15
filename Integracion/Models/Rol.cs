using System;
using System.Collections.Generic;

namespace Integracion.Models;

public partial class Rol
{
    public Guid IdRol { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
