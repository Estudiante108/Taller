using System;
using System.Collections.Generic;

namespace Taller_Caja.Models;

public partial class Transaccion
{
    public Guid IdTransaccion { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Estado { get; set; }

    public string? Datos { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
