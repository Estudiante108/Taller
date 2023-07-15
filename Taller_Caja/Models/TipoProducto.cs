using System;
using System.Collections.Generic;

namespace Taller_Caja.Models;

public partial class TipoProducto
{
    public Guid IdTipoProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
