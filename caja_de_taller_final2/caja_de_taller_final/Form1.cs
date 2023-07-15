using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace caja_de_taller_final
{
    public partial class Form1 : Form
    {
        string usuario, contrasena;
        public string cajero;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Form2 form2 = new Form2();
            usuario = txtnombre.Text;
            contrasena = txtcontrasena.Text;
            cajero = txtnombre.Text;

            if (usuario == "Avis" && contrasena == "1") 
            {
                form1.Hide();
                form2.Show();

               

            } 
            
            else if (usuario == "Mario" && contrasena == "2")
            {
                form1.Hide();
                form2.Show();



            }
            else 
            {
                MessageBox.Show("incorrecto intentelo de nuevo");
                txtnombre.Clear();
                txtcontrasena.Clear();
            }
 

        
        }
    }
}
