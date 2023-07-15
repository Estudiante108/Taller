using System;
using System.Collections.Generic;

namespace Taller_Caja.Models;

public partial class OrdenProducto
{
    public Guid IdOrdenTrabajo { get; set; }

    public Guid IdProducto { get; set; }

    public decimal? Precio { get; set; }

    public Guid? IdMecanico { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Mecanico? IdMecanicoNavigation { get; set; }

    public virtual OrdenTrabajo IdOrdenTrabajoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
