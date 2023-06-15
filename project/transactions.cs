using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class transactions : Form
    {
        public transactions()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void transactions_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Data Source=127.0.0.1,3306;User Id='root';password='';Database=atm");
            connection.Open();
            string query = "Select id_personne from card_b where card_number='" +atm.card_bancaire + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            query = "select * from transaction where id_personne='" + data.Rows[0]["id_personne"] +"'or id_pers='" + data.Rows[0]["id_personne"] +"'";
            adapter = new MySqlDataAdapter(query, connection);
            data = new DataTable();
            adapter.Fill(data);
            foreach (DataRow item in data.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["id_personne"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Id_pers"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["cash"].ToString();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            cash_withdraw withdraw = new cash_withdraw();
            withdraw.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            cash_availability availability=new cash_availability();
            availability.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            option option=new option();
            option.Show();
        }
    }
}
