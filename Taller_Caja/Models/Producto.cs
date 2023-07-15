using System;
using System.Collections.Generic;

namespace Taller_Caja.Models;

public partial class Producto
{
    public Guid IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? Stock { get; set; }

    public Guid? IdProveedor { get; set; }

    public Guid? IdTipoProducto { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<FacturaProducto> FacturaProductos { get; set; } = new List<FacturaProducto>();

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public virtual TipoProducto? IdTipoProductoNavigation { get; set; }
}
