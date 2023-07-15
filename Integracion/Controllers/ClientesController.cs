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
    public class ClientesController : ControllerBase
    {
        private readonly AutotechIntegracionContext _context;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ClientesController(AutotechIntegracionContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(Guid id)
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // GET: api/Clientes/Pendientes
        [HttpGet("Pendientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesPendientes()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }

            var clientesPendientes = await _context.Clientes.Where(c => c.Estado == "Pendiente").ToListAsync();

            if (clientesPendientes.Count == 0)
            {
                return NoContent();
            }

            // Actualizar los registros pendientes a completados
            foreach (var cliente in clientesPendientes)
            {
                cliente.Estado = "Completado";
                _context.Entry(cliente).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return clientesPendientes;
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        //{
        //  if (_context.Clientes == null)
        //  {
        //      return Problem("Entity set 'AutotechIntegracionContext.Clientes'  is null.");
        //  }
        //    _context.Clientes.Add(cliente);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ClienteExists(cliente.IdCliente))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
        //}

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'AutotechIntegracionContext.Clientes' is null.");
            }

            var existingCliente = await _context.Clientes.FindAsync(cliente.IdCliente);

            if (existingCliente == null)
            {
                var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") + "api/ClientesAPI", cliente);
                if (response.IsSuccessStatusCode)
                {
                    _context.Clientes.Add(cliente);
                }
                else
                {
                    cliente.Estado = "Pendiente";
                    _context.Clientes.Add(cliente);
                }
            }
            else
            {
                var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") +"api/ClientesAPI", cliente);
                if (response.IsSuccessStatusCode)
                {
                    _context.Entry(existingCliente).CurrentValues.SetValues(cliente);
                }
                else
                {
                    cliente.Estado = "Pendiente";
                    _context.Entry(existingCliente).CurrentValues.SetValues(cliente);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.IdCliente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
        }


        private bool ClienteExists(Guid id)
        {
            return (_context.Clientes?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }
    }
}
