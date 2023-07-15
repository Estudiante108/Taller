using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Integracion.Models;
using System.Net.Http;

namespace Integracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly AutotechIntegracionContext _context;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PagosController(AutotechIntegracionContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // GET: api/Pagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pago>>> GetPagos()
        {
          if (_context.Pagos == null)
          {
              return NotFound();
          }
            return await _context.Pagos.ToListAsync();
        }

        // GET: api/Pagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pago>> GetPago(Guid id)
        {
          if (_context.Pagos == null)
          {
              return NotFound();
          }
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            return pago;
        }

        [HttpGet("Pendientes")]
        public async Task<ActionResult<IEnumerable<Pago>>> GetPagosPendientes()
        {
            if (_context.Pagos == null)
            {
                return NotFound();
            }

            var pagosPendientes = await _context.Pagos.Where(p => p.Estado == "Pendiente").ToListAsync();

            if (pagosPendientes.Count == 0)
            {
                return NoContent();
            }

            // Actualizar los productos pendientes a completados
            foreach (var pagos in pagosPendientes)
            {
                pagos.Estado = "Completado";
                _context.Entry(pagos).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return pagosPendientes;
        }

        // POST: api/Pagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pago>> PostPago(Pago pago)
        {
          if (_context.Pagos == null)
          {
              return Problem("Entity set 'AutotechIntegracionContext.Pagos'  is null.");
          }
            var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") + "api/PagosAPI", pago);
            if (!response.IsSuccessStatusCode)
            {
                pago.Estado = "Pendiente";
            }
            _context.Pagos.Add(pago);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PagoExists(pago.IdPago))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPago", new { id = pago.IdPago }, pago);
        }

        private bool PagoExists(Guid id)
        {
            return (_context.Pagos?.Any(e => e.IdPago == id)).GetValueOrDefault();
        }
    }
}
