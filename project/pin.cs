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
    public partial class pin : Form
    {
        int attempt = 3;
        public pin()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string pin = textBox1.Text;
                if (pin.Length != 4)
                {
                    attempt -= 1;
                    if (attempt > 0)
                    {
                        label2.Text = "the pin is incorrect you still have" + attempt + "attempts";
                        return;
                    }
                    else
                    {
                        this.Hide();
                        atm atm = new atm();
                        atm.Show();
                        return;
                    }
                }
                MySqlConnection connection = new MySqlConnection("Data Source=127.0.0.1,3306;User Id='root';password='';Database=atm");
                connection.Open();
                string query = "select pin from card_b where card_number='"+atm.card_bancaire+"'and pin='"+pin+"'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    this.Hide();
                    option option = new option();
                    option.Show();
                }
                else
                {
                    attempt -= 1;
                    if (attempt > 0)
                    {
                        label2.Text = "the pin is incorrect you still have" + attempt + "attempts";
                        return;
                    }
                    else
                    {
                        this.Hide();
                        atm atm = new atm();
                        atm.Show();
                        return;
                    }
                }
            }
        }
    }
}
