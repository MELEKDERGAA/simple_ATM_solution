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
    public partial class modify_account : Form
    {
        public modify_account()
        {
            InitializeComponent();
        }

        private void Keypress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string pin = textBox1.Text;
                string pinc = textBox2.Text;
                MessageBox.Show("clicked enter");
                if (!pin.Equals(pinc))
                {
                    label4.Text= "the two pin are not the same";
                    return;   
                }
                MySqlConnection connection = new MySqlConnection("Data Source=127.0.0.1,3306;User Id='root';password='';Database=atm");
                connection.Open();
                string query = "update card_b set Pin='"+pin+"'where card_number='"+atm.card_bancaire+"'";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                this.Hide();
                option option=new option();
                option.Show();
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
            cash_availability availability = new cash_availability();
            availability.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            option option= new option();
            option.Show();
        }
    }
}
