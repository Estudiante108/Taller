using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Integracion.Models;
using System.Configuration;
using System.Net.Http;

namespace Integracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly AutotechIntegracionContext _context;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public VehiculosController(AutotechIntegracionContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
        {
          if (_context.Vehiculos == null)
          {
              return NotFound();
          }
            return await _context.Vehiculos.ToListAsync();
        }

        // GET: api/Vehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(Guid id)
        {
          if (_context.Vehiculos == null)
          {
              return NotFound();
          }
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        // GET: api/Vehiculos/Pendientes
        [HttpGet("Pendientes")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculosPendientes()
        {
            if (_context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculosPendientes = await _context.Vehiculos.Where(v => v.Estado == "Pendiente").ToListAsync();

            if (vehiculosPendientes.Count == 0)
            {
                return NoContent();
            }

            // Actualizar los vehículos pendientes a completados
            foreach (var vehiculo in vehiculosPendientes)
            {
                vehiculo.Estado = "Completado";
                _context.Entry(vehiculo).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return vehiculosPendientes;
        }



        // POST: api/Vehiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        //{
        //  if (_context.Vehiculos == null)
        //  {
        //      return Problem("Entity set 'AutotechIntegracionContext.Vehiculos'  is null.");
        //  }
        //    _context.Vehiculos.Add(vehiculo);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (VehiculoExists(vehiculo.IdVehiculo))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetVehiculo", new { id = vehiculo.IdVehiculo }, vehiculo);
        //}

        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
            if (_context.Vehiculos == null)
            {
                return Problem("Entity set 'AutotechIntegracionContext.Vehiculos' is null.");
            }

            var existingVehiculo = await _context.Vehiculos.FindAsync(vehiculo.IdVehiculo);

            if (existingVehiculo == null)
            {
                var response = await _httpClient.PostAsJsonAsync("https://api.example.com/api/VehiculosAPI", vehiculo);
                if (response.IsSuccessStatusCode)
                {
                    _context.Vehiculos.Add(vehiculo);
                }
                else
                {
                    vehiculo.Estado = "Pendiente";
                    _context.Vehiculos.Add(vehiculo);
                }
            }
            else
            {
                var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") + "api/VehiculosAPI", vehiculo);
                if (response.IsSuccessStatusCode)
                {
                    _context.Entry(existingVehiculo).CurrentValues.SetValues(vehiculo);
                }
                else
                {
                    vehiculo.Estado = "Pendiente";
                    _context.Entry(existingVehiculo).CurrentValues.SetValues(vehiculo);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VehiculoExists(vehiculo.IdVehiculo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.IdVehiculo }, vehiculo);
        }



        private bool VehiculoExists(Guid id)
        {
            return (_context.Vehiculos?.Any(e => e.IdVehiculo == id)).GetValueOrDefault();
        }
    }
}
