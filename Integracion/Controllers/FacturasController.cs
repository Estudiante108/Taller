using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Integracion.Models;
using Integracion.ViewModels;

namespace Integracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly AutotechIntegracionContext _context;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public FacturasController(AutotechIntegracionContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        {
            if (_context.Facturas == null)
            {
                return NotFound();
            }
            return await _context.Facturas.ToListAsync();
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(Guid id)
        {
            if (_context.Facturas == null)
            {
                return NotFound();
            }
            var factura = await _context.Facturas.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        // GET: api/FacturasProductos/Pendientes
        [HttpGet("Pendientes")]
        public async Task<ActionResult<IEnumerable<FacturaProducto>>> GetFacturasProductosPendientes()
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }

            var facturaProductosPendientes = await _context.FacturaProductos.Include(x=>x.IdFactura).Where(p => p.Estado == "Pendiente").ToListAsync();

            if (facturaProductosPendientes.Count == 0)
            {
                return NoContent();
            }

            // Actualizar los productos pendientes a completados
            foreach (var facturaProducto in facturaProductosPendientes)
            {
                facturaProducto.Estado = "Completado";
                _context.Entry(facturaProducto).State = EntityState.Modified;

                facturaProducto.IdFacturaNavigation.Estado = "Completado";
                _context.Entry(facturaProducto.IdFacturaNavigation).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return facturaProductosPendientes;
        }

        // POST: api/Facturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaProductos>> PostFactura(FacturaProductos facturaProductos)
        {
            if (_context.Facturas == null)
            {
                return Problem("Entity set 'AutotechIntegracionContext.Facturas'  is null.");
            }

            var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") + "api/FacturasAPI", facturaProductos);
            if (!response.IsSuccessStatusCode)
            {
                facturaProductos.factura.Estado = "Pendiente";
            }
            _context.Facturas.Add(facturaProductos.factura);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacturaExists(facturaProductos.factura.IdFactura))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            foreach (FacturaProducto producto in facturaProductos.productos)
            {
                if (!response.IsSuccessStatusCode)
                {
                    producto.Estado = "Pendiente";
                }
                _context.FacturaProductos.Add(producto);
                if (int.TryParse(producto.CantProd, out int stock))
                {
                    var existingProducto = await _context.Productos.FindAsync(producto.IdProducto);
                    if (existingProducto != null)
                    {

                        Producto p = existingProducto;
                        p.Stock = (int.Parse(p.Stock) - stock).ToString();
                        if (!response.IsSuccessStatusCode)
                        {
                            p.Estado = "Pendiente";
                        }
                        _context.Entry(existingProducto).CurrentValues.SetValues(p);
                    }

                }
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacturaExists(facturaProductos.factura.IdFactura))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetFactura", new { id = facturaProductos.factura.IdFactura }, facturaProductos);
        }

        private bool FacturaExists(Guid id)
        {
            return (_context.Facturas?.Any(e => e.IdFactura == id)).GetValueOrDefault();
        }
    }
}
