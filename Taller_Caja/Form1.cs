using Taller_Caja.Models;

namespace Taller_Caja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Form2 form2 = new Form2();
            string usuario = txtnombre.Text;
            string contrasena = txtcontrasena.Text;


            if (usuario == "Avis" && contrasena == "1")
            {
                this.Hide();
                form2.Show();



            }
            else if (usuario == "Mario" && contrasena == "12345678")
            {
                this.Hide();
                form2.Show();



            }
            else
            {
                MessageBox.Show("incorrecto intentelo de nuevo");
                txtnombre.Clear();
                txtcontrasena.Clear();
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}