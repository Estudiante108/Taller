using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Integracion.Models;
using System.Net.Http;
using System.Configuration;

namespace Integracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly AutotechIntegracionContext _context;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProveedoresController(AutotechIntegracionContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedors()
        {
          if (_context.Proveedors == null)
          {
              return NotFound();
          }
            return await _context.Proveedors.ToListAsync();
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(Guid id)
        {
          if (_context.Proveedors == null)
          {
              return NotFound();
          }
            var proveedor = await _context.Proveedors.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        // GET: api/Proveedores/Pendientes
        [HttpGet("Pendientes")]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedoresPendientes()
        {
            if (_context.Proveedors == null)
            {
                return NotFound();
            }

            var proveedoresPendientes = await _context.Proveedors.Where(p => p.Estado == "Pendiente").ToListAsync();

            if (proveedoresPendientes.Count == 0)
            {
                return NoContent();
            }

            // Update pending providers to completed
            foreach (var proveedor in proveedoresPendientes)
            {
                proveedor.Estado = "Completado";
                _context.Entry(proveedor).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return proveedoresPendientes;
        }

        // POST: api/Proveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        //{
        //  if (_context.Proveedors == null)
        //  {
        //      return Problem("Entity set 'AutotechIntegracionContext.Proveedors'  is null.");
        //  }
        //    _context.Proveedors.Add(proveedor);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ProveedorExists(proveedor.IdProveedor))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetProveedor", new { id = proveedor.IdProveedor }, proveedor);
        //}

        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
            if (_context.Proveedors == null)
            {
                return Problem("Entity set 'AutotechIntegracionContext.Proveedors' is null.");
            }

            var existingProveedor = await _context.Proveedors.FindAsync(proveedor.IdProveedor);

            if (existingProveedor == null)
            {
                var response = await _httpClient.PostAsJsonAsync("https://api.example.com/api/ProveedoresAPI", proveedor);
                if (response.IsSuccessStatusCode)
                {
                    _context.Proveedors.Add(proveedor);
                }
                else
                {
                    proveedor.Estado = "Pendiente";
                    _context.Proveedors.Add(proveedor);
                }
            }
            else
            {
                var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") + "api/ProveedoresAPI", proveedor);
                if (response.IsSuccessStatusCode)
                {
                    _context.Entry(existingProveedor).CurrentValues.SetValues(proveedor);
                }
                else
                {
                    proveedor.Estado = "Pendiente";
                    _context.Entry(existingProveedor).CurrentValues.SetValues(proveedor);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProveedorExists(proveedor.IdProveedor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProveedor", new { id = proveedor.IdProveedor }, proveedor);
        }




        private bool ProveedorExists(Guid id)
        {
            return (_context.Proveedors?.Any(e => e.IdProveedor == id)).GetValueOrDefault();
        }
    }
}
