using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ATM
{
    public partial class atm : Form
    {
        public static string card_bancaire;
        public atm()
        {
            InitializeComponent();
        }
        public void testing()
        {
            card_bancaire=textBox1.Text;
            if (card_bancaire.Length != 16)
            {
                MessageBox.Show("credit card number must be 16 digit");
                return;
            }
            MySqlConnection connection = new MySqlConnection("Data Source=127.0.0.1,3306;User Id='root';password='';Database=atm");
            connection.Open();
            string query = "Select card_number from card_b where card_number='" +card_bancaire+"'";
            MySqlCommand command=new MySqlCommand(query,connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows==false)
            {
                this.Hide();
                erreur_card erreur = new erreur_card();
                erreur.Show();
            }
            else
            {
                this.Hide();
                pin pin = new pin();
                pin.Show();
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                testing();
            }
        }
    }
}
