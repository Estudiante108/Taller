using System;
using System.Collections.Generic;

namespace Integracion.Models;

public partial class Vehiculo
{
    public Guid IdVehiculo { get; set; }

    public Guid? IdCliente { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public string? NumPlaca { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
