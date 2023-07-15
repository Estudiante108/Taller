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
using System.Data.SqlClient;


namespace Taller_Caja
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            using (var dbContext = new AutotechCajaContext())
            {
                var producto = await dbContext.TipoProductos.ToListAsync();
                boxtipoproducto.DataSource = producto;
                boxtipoproducto.DisplayMember = "Nombre";
                boxtipoproducto.ValueMember = "IdTipoProducto";

                var proveedor = await dbContext.Proveedors.ToListAsync();
                boxproveedor.DataSource = proveedor;
                boxproveedor.DisplayMember = "Nombre";
                boxproveedor.ValueMember = "IdProveedor";
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {



            using (var dbContext = new AutotechCajaContext())
            {

                Producto producto = new Producto();
                producto.IdProducto = Guid.NewGuid();
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtdescripcion.Text;
                producto.Precio = producto.Precio = Convert.ToInt32(txtPrecio.Text);
                producto.Stock = txtStock.Text;
                producto.IdTipoProducto = (Guid?)boxtipoproducto.SelectedValue;
                producto.IdProveedor = (Guid?)boxproveedor.SelectedValue;
                producto.Estado = txtEstado.Text;
                dbContext.Productos.Add(producto);
                await dbContext.SaveChangesAsync();
            }
            MessageBox.Show("guardado exitoso");
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void boxproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            Form2 form2 = new Form2();

            this.Close();
            form2.Show();
        }

        private void boxtipoproducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
