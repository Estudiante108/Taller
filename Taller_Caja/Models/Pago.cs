using System;
using System.Collections.Generic;

namespace Taller_Caja.Models;

public partial class Pago
{
    public Guid IdPago { get; set; }

    public Guid? IdFactura { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }
}
