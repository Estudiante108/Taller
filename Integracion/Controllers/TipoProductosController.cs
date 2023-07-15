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
    public class TipoProductosController : ControllerBase
    {
        private readonly AutotechIntegracionContext _context;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TipoProductosController(AutotechIntegracionContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // GET: api/TipoProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProducto>>> GetTipoProductos()
        {
          if (_context.TipoProductos == null)
          {
              return NotFound();
          }
            return await _context.TipoProductos.ToListAsync();
        }

        // GET: api/TipoProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProducto>> GetTipoProducto(Guid id)
        {
          if (_context.TipoProductos == null)
          {
              return NotFound();
          }
            var tipoProducto = await _context.TipoProductos.FindAsync(id);

            if (tipoProducto == null)
            {
                return NotFound();
            }

            return tipoProducto;
        }

        // GET: api/TipoProductos/Pendientes
        [HttpGet("Pendientes")]
        public async Task<ActionResult<IEnumerable<TipoProducto>>> GetTipoProductosPendientes()
        {
            if (_context.TipoProductos == null)
            {
                return NotFound();
            }

            var tipoProductosPendientes = await _context.TipoProductos.Where(tp => tp.Estado == "Pendiente").ToListAsync();

            if (tipoProductosPendientes.Count == 0)
            {
                return NoContent();
            }

            // Update pending type of products to completed
            foreach (var tipoProducto in tipoProductosPendientes)
            {
                tipoProducto.Estado = "Completado";
                _context.Entry(tipoProducto).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return tipoProductosPendientes;
        }

        [HttpPost]
        public async Task<ActionResult<TipoProducto>> PostTipoProducto(TipoProducto tipoProducto)
        {
            if (_context.TipoProductos == null)
            {
                return Problem("Entity set 'AutotechIntegracionContext.TipoProductos' is null.");
            }

            var existingTipoProducto = await _context.TipoProductos.FindAsync(tipoProducto.IdTipoProducto);

            if (existingTipoProducto == null)
            {
                var response = await _httpClient.PostAsJsonAsync("https://api.example.com/api/TipoProductosAPI", tipoProducto);
                if (response.IsSuccessStatusCode)
                {
                    _context.TipoProductos.Add(tipoProducto);
                }
                else
                {
                    tipoProducto.Estado = "Pendiente";
                    _context.TipoProductos.Add(tipoProducto);
                }
            }
            else
            {
                var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") + "api/TipoProductosAPI", tipoProducto);
                if (response.IsSuccessStatusCode)
                {
                    _context.Entry(existingTipoProducto).CurrentValues.SetValues(tipoProducto);
                }
                else
                {
                    tipoProducto.Estado = "Pendiente";
                    _context.Entry(existingTipoProducto).CurrentValues.SetValues(tipoProducto);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoProductoExists(tipoProducto.IdTipoProducto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoProducto", new { id = tipoProducto.IdTipoProducto }, tipoProducto);
        }





        private bool TipoProductoExists(Guid id)
        {
            return (_context.TipoProductos?.Any(e => e.IdTipoProducto == id)).GetValueOrDefault();
        }
    }
}
