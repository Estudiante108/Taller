using System;
using System.Collections.Generic;

namespace Taller_Caja.Models;

public partial class OrdenTrabajo
{
    public Guid IdOrdenTrabajo { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Estado { get; set; }

    public string? Descripcion { get; set; }

    public Guid? IdFactura { get; set; }

    public Guid? IdProducto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual ICollection<OrdenProducto> OrdenProductos { get; set; } = new List<OrdenProducto>();
}
