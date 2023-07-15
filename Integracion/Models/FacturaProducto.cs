using System;
using System.Collections.Generic;

namespace Integracion.Models;

public partial class FacturaProducto
{
    public Guid IdFactura { get; set; }

    public Guid IdProducto { get; set; }

    public decimal? Precio { get; set; }

    public Guid? IdMecanico { get; set; }

    public string? CantProd { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Factura IdFacturaNavigation { get; set; } = null!;

    public virtual Mecanico? IdMecanicoNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
