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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace Taller_Caja
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            using (var dbContext = new AutotechCajaContext())
            {
                var vehiculo = await dbContext.Vehiculos.ToListAsync();
                Numeroplaca.DataSource = vehiculo;
                Numeroplaca.DisplayMember = "Num_placa";
                Numeroplaca.ValueMember = "IdVehiculo";

                var producto = await dbContext.Productos.ToListAsync();
                productos.DataSource = producto;
                productos.DisplayMember = "Nombre";
                productos.ValueMember = "IdProducto";

                var mecanico = await dbContext.Mecanicos.ToListAsync();
                mecanicos.DataSource = mecanico;
                mecanicos.DisplayMember = "Nombre";
                mecanicos.ValueMember = "IdMecanico";
            }
        }

        private void GeneratePdfFromString(Factura factura, string filePath)
        {
            // Create a new PDF document
            Document document = new Document();

            // Create a new PDF writer
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

            // Open the PDF document
            document.Open();

            // Add content to the PDF document
            // Invoice title
            Paragraph title = new Paragraph("Factura");
            title.Alignment = Element.ALIGN_CENTER;
            title.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18f);
            document.Add(title);

            // Invoice details
            Paragraph details = new Paragraph();
            details.Alignment = Element.ALIGN_LEFT;
            details.Add(Chunk.NEWLINE);
            details.Add(Chunk.NEWLINE);
            details.Add(new Chunk("Fecha Creacion Factura:"));
            details.Add(new Chunk(factura.FechaCreacion.ToString()));
            details.Add(Chunk.NEWLINE);
            details.Add(new Chunk("ID Factura:"));
            details.Add(new Chunk(factura.IdFactura.ToString()));
            details.Add(Chunk.NEWLINE);
            details.Add(new Chunk("ID Vehiculo:"));
            details.Add(new Chunk(factura.IdVehiculo.ToString()));
            details.Add(Chunk.NEWLINE);
            details.Add(new Chunk("Monto a Pagar:"));
            details.Add(new Chunk(factura.Total.ToString()));
            details.Add(Chunk.NEWLINE);
            document.Add(details);

            // Close the PDF document
            document.Close();

            // Open the PDF file using the default associated program
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public int Precio = 0;
        public int Totalfinal = 0;
        public int cantidad = 0;
        public int Cantidadval = 0;
        public int Valor = 0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            boxcantidad.Text = Convert.ToString(Cantidadval - cantidad);

            var selectedProduct = productos.SelectedItem as Producto;
            boxcantidad.Text = selectedProduct?.Stock;
            Cantidadval = Convert.ToInt32(boxcantidad.Text);

            var selectedProduct1 = productos.SelectedItem as Producto;
            Precio = Convert.ToInt32(selectedProduct?.Precio);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

           
            if (int.TryParse(txtcantidad.Text, out int valor))
            {
                if (valor > Cantidadval)
                {
                    MessageBox.Show("Por favor, digite una cantidad válida");
                }
                else
                {
                    Valor = valor;
                    // Additional code for handling the valid input
                }
            }
            else
            {
                MessageBox.Show("Por favor, digite una cantidad válida");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string NumeroPlaca = Numeroplaca.Text;
            string Producto = productos.Text;
            string Mecanico = mecanicos.Text;
            int cantidad = Convert.ToInt32(txtcantidad.Text);

            using (var dbContext = new AutotechCajaContext())
            {
                // Find the product by name
                var product = await dbContext.Productos.FirstOrDefaultAsync(p => p.Nombre == Producto);
                if (product != null)
                {
                    // Convert the stock value from string to int
                    int stock = Convert.ToInt32(product.Stock);

                    // Subtract the quantity from the stock
                    stock -= cantidad;

                    // Convert the stock back to string and assign it to the product
                    product.Stock = stock.ToString();

                    // Save the changes to the database
                    await dbContext.SaveChangesAsync();
                }
            }

            Totalfinal = (Precio * cantidad);


            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dataGridView1);

            // aqui le voy a pasar al datagrid
            file.Cells[0].Value = NumeroPlaca;
            file.Cells[1].Value = Mecanico;
            file.Cells[2].Value = Producto; // combo box
            file.Cells[3].Value = cantidad;
            file.Cells[4].Value = Precio;
            file.Cells[5].Value = Totalfinal;



            // terminamos de colocar los datos, ahora falta pasarlos



            dataGridView1.Rows.Add(file); // esto es para que de agregen

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            using (var dbContext = new AutotechCajaContext())
            {


                // Accede a los datos utilizando las propiedades DbSet generadas
                //var productos = dbContext.Productos.ToListAsync();
                Factura factura = new Factura();
                factura.IdFactura = Guid.NewGuid();
                factura.IdVehiculo = (Guid?)Numeroplaca.SelectedValue;
                factura.Total = Totalfinal;
                factura.FechaCreacion = DateTime.Now;
                // Realiza operaciones de CRUD
                dbContext.Facturas.Add(factura);
                await dbContext.SaveChangesAsync();
            }
            MessageBox.Show("guardado exitoso");
        }

        private void button3_Click(object sender, EventArgs e)
        {

                Factura factura = new Factura();
                factura.IdFactura = Guid.NewGuid();
                factura.IdVehiculo = (Guid?)Numeroplaca.SelectedValue;
                factura.Total = Totalfinal;
                factura.FechaCreacion = DateTime.Now;

                GeneratePdfFromString(factura, @"C:\Users\Mario\Downloads\Factura.pdf");
            


        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            frmCliente formcliente = new frmCliente();

            this.Hide();
            formcliente.Show();
        }

        private void registrarVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            frmvehiculo formvehiculo = new frmvehiculo();

            this.Hide();
            formvehiculo.Show();
        }

        private void registrarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Form3 registroprod = new Form3();

            this.Hide();
            registroprod.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Form1 login = new Form1();

            this.Close();
            login.Show();
        }
    }
}
