using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caja_de_taller_final
{
    public partial class Form2 : Form
    {
        string tipoDocumento, documento, nombre, mensaje;
        string EmpleadoNomnbre, EmpleadoApellido, EmpleadoTipoDocumento, EmpleadoDocumento;
        double FacturaTotal, FacturaPrecio, FacturaCantidad, FacturaTipo, FacturaDescripcion;

        private void geeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            Form2 form2 = new Form2();
            form3.Show();
            form2.Hide();
            
        }

        private void diaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            Form2 form2 = new Form2();

            form4.Show(); 
            form2.Hide();
        }

        private void btndata_Click(object sender, EventArgs e)
        {

            

        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          


            clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();

            Ticket1.TextoCentro("Taller "); //imprime una linea de descripcion
            Ticket1.TextoCentro("**********************************");
            Form1 form1 = new Form1();
            /*Ticket1.TextoIzquierda("Dirc: xxxx");
            Ticket1.TextoIzquierda("Tel:xxxx ");
            Ticket1.TextoIzquierda("Rnc: xxxx"); */
            Ticket1.TextoIzquierda("");
            Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
            Ticket1.TextoIzquierda("No Fac: 0120120"); 
            Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
            Ticket1.TextoIzquierda(mensaje);
            Ticket1.TextoIzquierda("");
            clsFactura.CreaTicket.LineasGuion();

            clsFactura.CreaTicket.EncabezadoVenta();
            clsFactura.CreaTicket.LineasGuion();
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                // PROD                     //PrECIO                                    CANT                         TOTAL
                Ticket1.AgregaArticulo(r.Cells[2].Value.ToString(), r.Cells[1].Value.ToString(), double.Parse(r.Cells[3].Value.ToString()), int.Parse(r.Cells[4].Value.ToString()), double.Parse(r.Cells[5].Value.ToString())); //imprime una linea de descripcion
            }


            clsFactura.CreaTicket.LineasGuion();
            /*Ticket1.AgregaTotales("Sub-Total", double.Parse("000")); // imprime linea con Subtotal
            Ticket1.AgregaTotales("Menos Descuento", double.Parse("000")); // imprime linea con decuento total
            Ticket1.AgregaTotales("Mas ITBIS", double.Parse("000")); // imprime linea con ITBis total */
            Ticket1.TextoIzquierda("");
            Ticket1.AgregaTotales("Total", double.Parse(lbltotalapagar2.Text)); // imprime linea con total
            Ticket1.TextoIzquierda(" ");
            Ticket1.AgregaTotales("Efectivo Entregado:", double.Parse(txtefectivo.Text));
            Ticket1.AgregaTotales("Efectivo Devuelto:", double.Parse(lbldevolucion2.Text));


            // Ticket1.LineasTotales(); // imprime linea 

            Ticket1.TextoIzquierda(" ");
            Ticket1.TextoCentro("**********************************");
            Ticket1.TextoCentro("*     Gracias por preferirnos    *");

            Ticket1.TextoCentro("**********************************");
            Ticket1.TextoIzquierda(" ");
            string impresora = "Microsoft XPS Document Writer";
            Ticket1.ImprimirTiket(impresora);




           /* Fila = 0;
            while (dataGridView1.RowCount > 0)//limpia el dgv
            { dataGridView1.Rows.Remove(dataGridView1.CurrentRow); }
            //LBLIDnuevaFACTURA.Text = ClaseFunciones.ClsFunciones.IDNUEVAFACTURA().ToString();

            txtIdProducto.Text = lblNombre.Text = txtCantidad.Text = textBox3.Text = "";
            lblCostoApagar.Text = lbldevolucion.Text = lblPrecio.Text = "0";
            txtIdProducto.Focus(); */
            MessageBox.Show("Gracias por preferirnos");

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ct"].ConnectionString); // no e colocado el conetion
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            SqlTransaction sqlTransaction = null;
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.Transaction = sqlTransaction;


            Form2 form2 = new Form2();
            string ClienteNombre = form2.txtNombre.Text;
            string ClienteTipoDocumento = form2.cmbTipoDocumento.Text;
            string ClienteDocumento = form2.txtDocumento.Text;
            double Total = double.Parse(lbltotalapagar2.Text);

            sqlCommand.CommandText = "ppInsertFactura"; 

            sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
            sqlCommand.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
            sqlCommand.Parameters.AddWithValue("@Documento", documento);
            sqlCommand.Parameters.AddWithValue("@Total", Total);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();

           



            this.Close();


        }

        private void cmbtipo_SelectedIndexChanged(object sender, EventArgs e) // combobox
        {
            int codigo;
            codigo = cmbtipo.SelectedIndex;

            switch (codigo) 
            {
                case 0:lblcodigo2.Text = "0011"; break;
                case 1: lblcodigo2.Text= "0022"; break;
            }

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            
            tipoDocumento = cmbTipoDocumento.Text;
            documento = txtDocumento.Text;
            nombre = txtNombre.Text;
            mensaje =  nombre +", "+ tipoDocumento +"-"+ documento ;






            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dataGridView1);

            // aqui le voy a pasar al datagrid
            file.Cells[0].Value = lblcodigo2.Text;
            file.Cells[1].Value = cmbtipo.Text; // combo box
            file.Cells[2].Value = txtdescripcion.Text;
            file.Cells[3].Value = txtprecio.Text;
            file.Cells[4].Value = txtcantidad.Text;
            file.Cells[5].Value = (double.Parse(txtprecio.Text) * double.Parse(txtcantidad.Text)).ToString() ;
            // terminamos de colocar los datos, ahora falta pasarlos

            

            dataGridView1.Rows.Add(file); // esto es para que de agregen

            lblcodigo2.Text = cmbtipo.Text = txtprecio.Text = txtcantidad.Text = txtdescripcion.Text = "";

            ObtenerTotal();


        }

        public void ObtenerTotal() 
        {
            float costot = 0;
            int contador = 0;

            contador = dataGridView1.RowCount; // numero de rows del datagrid

            for (int i = 0; i < contador; i++) 
            {
                costot += float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            
            }

            lbltotalapagar2.Text = costot.ToString();
            FacturaTotal = double.Parse(lbltotalapagar2.Text); //peeppepepepeepeeppe

        
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("desea eliminarlo",
                    "eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes) 
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                
                }

            }
            catch 
            { 
            
            }

            ObtenerTotal();

        }

        private void txtefectivo_TextChanged(object sender, EventArgs e)
        {
            // cuando ingrese la cantidad de efectivo que yo tengo me lo tiene q restar con la cantidad de valor total

            try 
            {
                lbldevolucion2.Text = (double.Parse(txtefectivo.Text) - double.Parse(lbltotalapagar2.Text)).ToString();
            
            }
            catch { }



        }
    }
}
