using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller_Caja.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Taller_Caja
{
    public partial class frmvehiculo : Form
    {
        public frmvehiculo()
        {
            InitializeComponent();
        }

        private void Combocliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void frmvehiculo_Load(object sender, EventArgs e)
        {
            using (var dbContext = new AutotechCajaContext())
            {
                var cliente = await dbContext.Clientes.ToListAsync();
                Combocliente.DataSource = cliente;
                Combocliente.DisplayMember = "Nombre";
                Combocliente.ValueMember = "IdCliente";


            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var dbContext = new AutotechCajaContext())
            {
                // Accede a los datos utilizando las propiedades DbSet generadas
                //var productos = dbContext.Productos.ToListAsync();
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.IdVehiculo = Guid.NewGuid();
                vehiculo.IdCliente = (Guid?)Combocliente.SelectedValue;
                vehiculo.Marca = txtmarca.Text;
                vehiculo.Modelo = txtModelo.Text;
                vehiculo.NumPlaca = txtplaca.Text;
                vehiculo.Anio = Convert.ToInt32(txtano.Text);
                vehiculo.FechaCreacion = DateTime.Now;
                vehiculo.FechaActualizacion = DateTime.Now;
                // Realiza operaciones de CRUD
                dbContext.Vehiculos.Add(vehiculo);
                await dbContext.SaveChangesAsync();
            }
            MessageBox.Show("guardado exitoso");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmvehiculo formvehiculo = new frmvehiculo();
            Form2 form2 = new Form2();

            this.Close();
            form2.Show();
        }
    }
}
