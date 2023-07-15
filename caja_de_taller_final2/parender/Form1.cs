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

namespace parender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ct"].ConnectionString); // no e colocado el conetion
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            SqlTransaction sqlTransaction = null;
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            sqlCommand.Transaction = sqlTransaction;
            sqlCommand.CommandText = "ppInsertCliente2"; // no le e colocado el nombre

            sqlCommand.Parameters.AddWithValue("@Nombre", ClienteNombre);
            sqlCommand.Parameters.AddWithValue("@TipoDocumento", ClienteTipoDocumento);
            sqlCommand.Parameters.AddWithValue("@Documento", ClienteDocumento);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
        }
    }
}
