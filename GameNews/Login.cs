using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameNews.Logic;

namespace GameNews
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "";

            if (textBox1.Text == String.Empty)
                label4.Text = "not empty";
            else
                label4.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "";

            if (textBox2.Text == String.Empty)
                label5.Text = "not empty";
            else
                label5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check = false;
            List<Account> accounts = GameNews.Logic.AccountList.getAllAccount();
            foreach(Account account in accounts)
            {
                if(account.username.Equals(textBox1.Text) && account.password.Equals(textBox2.Text))
                {
                    if (account.isAdmin)
                    {
                        check = true;
                        Admin form1 = new Admin(account);
                        form1.Show();
                        form1.FormClosed += formClose;
                        this.Visible = false;
                    }
                    if (!account.isAdmin && account.isWriter)
                    {
                        check = true;
                        Writer form1 = new Writer(account);
                        form1.Show();
                        form1.FormClosed += formClose;
                        this.Visible = false;
                    }
                }
                
            }
            if (!check)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                label6.Text = "Username or password is incorrect";
                
            }
                
        }
        private void formClose(object sender, EventArgs e)
        {
            this.Visible = true;
            Login_Load(sender, e);
        }
    }
}
