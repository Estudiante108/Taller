using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Taller_Caja.Models;
using Microsoft.EntityFrameworkCore;

namespace Taller_Caja
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {


        }

        private void vehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmvehiculo frmvehiculo = new frmvehiculo();
            frmCliente frmCliente = new frmCliente();
            frmCliente.Hide();
            frmvehiculo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCliente formcliente = new frmCliente();
            Form2 form2 = new Form2();

            this.Close();
            form2.Show();
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            using (var dbContext = new AutotechCajaContext())
            {
                // Accede a los datos utilizando las propiedades DbSet generadas
                //var productos = dbContext.Productos.ToListAsync();
                Cliente cliente = new Cliente();
                cliente.IdCliente = Guid.NewGuid();
                cliente.Nombre = textBox3.Text;
                cliente.Telefono = textBox1.Text;
                cliente.Email = textBox4.Text;
                cliente.Direccion = textBox2.Text;
                cliente.FechaCreacion = DateTime.Now;
                cliente.FechaActualizacion = DateTime.Now;
                // Realiza operaciones de CRUD
                dbContext.Clientes.Add(cliente);
                await dbContext.SaveChangesAsync();
            }
            MessageBox.Show("guardado exitoso");
        }
    }
}

