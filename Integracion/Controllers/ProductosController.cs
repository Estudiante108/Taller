using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Integracion.Models;

namespace Integracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AutotechIntegracionContext _context;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProductosController(AutotechIntegracionContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
          if (_context.Productos == null)
          {
              return NotFound();
          }
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(Guid id)
        {
          if (_context.Productos == null)
          {
              return NotFound();
          }
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // GET: api/Productos/Pendientes
        [HttpGet("Pendientes")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosPendientes()
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }

            var productosPendientes = await _context.Productos.Where(p => p.Estado == "Pendiente").ToListAsync();

            if (productosPendientes.Count == 0)
            {
                return NoContent();
            }

            // Actualizar los productos pendientes a completados
            foreach (var producto in productosPendientes)
            {
                producto.Estado = "Completado";
                _context.Entry(producto).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return productosPendientes;
        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        //{
        //  if (_context.Productos == null)
        //  {
        //      return Problem("Entity set 'AutotechIntegracionContext.Productos'  is null.");
        //  }
        //    _context.Productos.Add(producto);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ProductoExists(producto.IdProducto))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetProducto", new { id = producto.IdProducto }, producto);
        //}

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'AutotechIntegracionContext.Productos' is null.");
            }

            var existingProducto = await _context.Productos.FindAsync(producto.IdProducto);

            if (existingProducto == null)
            {
                var response = await _httpClient.PostAsJsonAsync("https://api.example.com/api/ProductosAPI", producto);
                if (response.IsSuccessStatusCode)
                {
                    _context.Productos.Add(producto);
                }
                else
                {
                    producto.Estado = "Pendiente";
                    _context.Productos.Add(producto);
                }
            }
            else
            {
                var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") + "api/ProductosAPI", producto);
                if (response.IsSuccessStatusCode)
                {
                    _context.Entry(existingProducto).CurrentValues.SetValues(producto);
                }
                else
                {
                    producto.Estado = "Pendiente";
                    _context.Entry(existingProducto).CurrentValues.SetValues(producto);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductoExists(producto.IdProducto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProducto", new { id = producto.IdProducto }, producto);
        }




        private bool ProductoExists(Guid id)
        {
            return (_context.Productos?.Any(e => e.IdProducto == id)).GetValueOrDefault();
        }
    }
}
