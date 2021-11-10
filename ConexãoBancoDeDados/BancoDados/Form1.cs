using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BancoDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Properties.Settings.Default.CST;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM tb_clientes";
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();

                MessageBox.Show("Conexão Criada com Sucesso!");
            }
            catch( Exception ex)
            {
                MessageBox.Show(String.Format("Falha na Conexão: {0}", ex.Message));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
