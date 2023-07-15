using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Taller_Caja.Models;




namespace Taller_Caja
{
        public class ClientesEndpoint
        {
            private readonly AutotechCajaContext _context;
            private readonly HttpClient _httpClient;
            private readonly IConfiguration _configuration;

            public ClientesEndpoint(AutotechCajaContext context, HttpClient httpClient, IConfiguration configuration)
            {
                _context = context;
                _httpClient = httpClient;
                _configuration = configuration;
            }

            public async Task<List<Cliente>> GetClientes()
            {
                if (_context.Clientes == null)
                {
                    MessageBox.Show("No hay elementos en la lista.");
                    return null;
                }

                return await _context.Clientes.ToListAsync();
            }

            public async Task<Cliente> GetCliente(Guid id)
            {
                if (_context.Clientes == null)
                {
                    MessageBox.Show("No hay elementos en la lista.");
                    return null;
                }

                var cliente = await _context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente no encontrado.");
                    return null;
                }

                return cliente;
            }

            public async Task<List<Cliente>> GetClientesPendientes()
            {
                if (_context.Clientes == null)
                {
                    MessageBox.Show("No hay elementos en la lista.");
                    return null;
                }

                var clientesPendientes = await _context.Clientes.Where(c => c.Estado == "Pendiente").ToListAsync();

                if (clientesPendientes.Count == 0)
                {
                    MessageBox.Show("No hay clientes pendientes.");
                    return null;
                }

                // Update pending records to completed
                foreach (var cliente in clientesPendientes)
                {
                    cliente.Estado = "Completado";
                    _context.Entry(cliente).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();

                return clientesPendientes;
            }

            public async Task<Cliente> PostCliente(Cliente cliente)
            {
                if (_context.Clientes == null)
                {
                    MessageBox.Show("No hay elementos en la lista.");
                    return null;
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
                    var response = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Autotech_Core") + "api/ClientesAPI", cliente);
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
                        MessageBox.Show("Conflicto: Cliente existe.");
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }

                return cliente;
            }

            private bool ClienteExists(Guid id)
            {
                return (_context.Clientes?.Any(e => e.IdCliente == id)).GetValueOrDefault();
            }
        }
}
