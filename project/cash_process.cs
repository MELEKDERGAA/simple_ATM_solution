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
    public partial class cash_process : Form
    {
        public cash_process()
        {
            InitializeComponent();
        }

        private void cash_process_Load(object sender, EventArgs e)
        {
            linkLabel1.Hide();
            linkLabel2.Hide();
            if (cash_withdraw.done_withdraw)
            {
                label1.ForeColor = Color.Green;
                label1.Text = cash_withdraw.text;
                linkLabel1.Show();
                linkLabel2.Show();
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = cash_withdraw.text;
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
            atm atm = new atm();
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
