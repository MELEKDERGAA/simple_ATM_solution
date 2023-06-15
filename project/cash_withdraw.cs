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
    public partial class cash_withdraw : Form
    {
        public static bool done_withdraw=false;
        public static string text;
        public cash_withdraw()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button=(Button)sender;
            string cash=button.Text.Replace('$',' ');
            MySqlConnection connection = new MySqlConnection("Data Source=127.0.0.1,3306;User Id='root';password='';Database=atm");
            connection.Open();
            string query = "Select id_personne from card_b where card_number='" + atm.card_bancaire + "'";
            MySqlDataAdapter adap = new MySqlDataAdapter(query, connection);
            DataTable dat = new DataTable();
            adap.Fill(dat);
            query = "Select bank_number,cash_available from bank_account where id_personne='" + dat.Rows[0]["id_personne"] + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            query = "insert into withdraw (card_number,id_personne,bank_number,cash) values('" + atm.card_bancaire + "','" + dat.Rows[0]["id_personne"] + "','" + data.Rows[0]["bank_number"]+"','"+cash+"')";
            int n=0;
            MySqlCommand command;
            try
            {
                if ((int)data.Rows[0]["cash_available"] - Convert.ToInt32(cash) >= 0)
                {
                    command = new MySqlCommand(query, connection);
                    n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        done_withdraw = true;
                        text = "the withdraw is successfuly done";
                    }
                    else
                    {
                        text = "erreur there are something wrong please contact the bank or try another atm";
                        done_withdraw = false;
                    }
                }
                else
                {
                    text = "you have no cash available in your bank account";
                    done_withdraw = false;
                }
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
            if (done_withdraw)
            {
                query = "update bank_account set cash_available= cash_available-'" + cash + "'where bank_number='" + data.Rows[0]["bank_number"] + "'";
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            this.Hide();
            cash_process process = new cash_process();
            process.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            option option = new option();
            option.Show();
        }
    }
}
