using System;
using System.Collections.Generic;

namespace Integracion.Models;

public partial class Factura
{
    public Guid IdFactura { get; set; }

    public decimal? Total { get; set; }

    public Guid? IdVehiculo { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<FacturaProducto> FacturaProductos { get; set; } = new List<FacturaProducto>();

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
