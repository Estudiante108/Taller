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
    public class MecanicosController : ControllerBase
    {
        private readonly AutotechIntegracionContext _context;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MecanicosController(AutotechIntegracionContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // GET: api/Mecanicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mecanico>>> GetMecanicos()
        {
            if (_context.Mecanicos == null)
            {
                return NotFound();
            }
            return await _context.Mecanicos.ToListAsync();
        }

        // GET: api/Mecanicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecanico>> GetMecanico(Guid id)
        {
            if (_context.Mecanicos == null)
            {
                return NotFound();
            }
            var mecanico = await _context.Mecanicos.FindAsync(id);
            //var ejemplo = _context.Usuarios.Include(x => x.IdRolNavigation).ToListAsync(); //ejemplo de join
            if (mecanico == null)
            {
                return NotFound();
            }

            return mecanico;
        }


        // POST: api/Mecanicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Mecanico>> PostMecanico(Mecanico mecanico)
        //{
        //  if (_context.Mecanicos == null)
        //  {
        //      return Problem("Entity set 'AutotechIntegracionContext.Mecanicos'  is null.");
        //  }
        //    _context.Mecanicos.Add(mecanico);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (MecanicoExists(mecanico.IdMecanico))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetMecanico", new { id = mecanico.IdMecanico }, mecanico);
        //}

        // GET: api/Productos/Pendientes
        [HttpGet("Pendientes")]
        public async Task<ActionResult<IEnumerable<Mecanico>>> GetMecanicosPendientes()
        {
            if (_context.Mecanicos == null)
            {
                return NotFound();
            }

            var mecanicosPendientes = await _context.Mecanicos.Where(p => p.Estado == "Pendiente").ToListAsync();

            if (mecanicosPendientes.Count == 0)
            {
                return NoContent();
            }

            // Actualizar los productos pendientes a completados
            foreach (var mecanico in mecanicosPendientes)
            {
                mecanico.Estado = "Completado";
                _context.Entry(mecanico).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return mecanicosPendientes;
        }

        // POST: api/Mecanicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mecanico>> PostMecanico(Mecanico mecanico)
        {
            if (_context.Mecanicos == null)
            {
                return Problem("Entity set 'AutotechIntegracionContext.Mecanicos' is null.");
            }

            var existingMecanico = await _context.Mecanicos.FindAsync(mecanico.IdMecanico);

            var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") + "api/MecanicosAPI", mecanico);
            if (!response.IsSuccessStatusCode)
            {
                mecanico.Estado = "Pendiente";
            }

            if (existingMecanico == null)
            {
                _context.Mecanicos.Add(mecanico);
            }
            else
            {
                _context.Entry(existingMecanico).CurrentValues.SetValues(mecanico);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MecanicoExists(mecanico.IdMecanico))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMecanico", new { id = mecanico.IdMecanico }, mecanico);
        }


        private bool MecanicoExists(Guid id)
        {
            return (_context.Mecanicos?.Any(e => e.IdMecanico == id)).GetValueOrDefault();
        }
    }
}
