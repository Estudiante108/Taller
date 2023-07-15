using Integracion.Models;

namespace Integracion.ViewModels
{
    public class FacturaProductos
    {
        public Factura factura { get; set; }
        public List<FacturaProducto> productos { get; set; }
    }
}
