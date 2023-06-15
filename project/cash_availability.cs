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
    public partial class cash_availability : Form
    {
        public static string id_personne;
        public static int cash_available;
        public cash_availability()
        {
            InitializeComponent();
        }

        private void cash_availability_Load(object sender, EventArgs e)
        {
            string card_bank = atm.card_bancaire;
            MySqlConnection connection = new MySqlConnection("Data Source=127.0.0.1,3306;User Id='root';password='';Database=atm");
            connection.Open();
            string query = "Select id_personne from card_b where card_number='"+card_bank+"'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query,connection);
            DataTable data=new DataTable();
            adapter.Fill(data);
            id_personne = data.Rows[0]["id_personne"].ToString();
            query ="Select bank_account.cash_available,personne.name from bank_account inner join personne where personne.ID='" + data.Rows[0]["id_personne"]+ "'and bank_account.id_personne='" + data.Rows[0]["id_personne"]+"'";
            adapter = new MySqlDataAdapter(query,connection);
            data=new DataTable();
            adapter.Fill(data);
            cash_available = (int)data.Rows[0]["cash_available"];
            foreach(DataRow item in data.Rows)
            {
                label1.Text="hello Mr(s)." + item["name"].ToString()+"your account balance is $" + item["cash_available"].ToString();
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
            atm atm=new atm();
            atm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            option option = new option();
            option.Show();
        }
    }
}
