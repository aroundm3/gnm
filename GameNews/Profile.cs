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
    public partial class Profile : Form
    {
        Account currentAccount;
        string imagePath = "";
        string password = "";

        public Profile()
        {
            InitializeComponent();
        }

        public Profile(Account account)
        {
            this.currentAccount = account;
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + currentAccount.avatar);
            textBox1.Text = currentAccount.username;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox2.Text = currentAccount.email;

            textBox3.Visible = false;
            textBox4.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }

        

        private void label8_Click(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            textBox4.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;

            label4.Text = "";
            label6.Text = "";
            label7.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
            }
            imagePath = opnfd.FileName.Substring(opnfd.FileName.LastIndexOf(@"\") + 1);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do u want save the change of " + currentAccount.username, "Comfirm ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!imagePath.Equals(string.Empty))
                {
                    GameNews.Logic.Account.updateImageOfavaterAccount(imagePath, currentAccount.username);
                    currentAccount.avatar = imagePath;
                }

                if (textBox3.Text == textBox4.Text && !textBox3.Text.Equals(string.Empty) && !textBox4.Text.Equals(string.Empty))
                {
                    GameNews.Logic.Account.updatePasswordAccount(currentAccount.username, textBox3.Text);
                    currentAccount.password = textBox3.Text;
                    this.Close();
                }
                else
                {
                    label7.Text = "Confirm password is incorrect";
                }
                
            } 

            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label7.Text = "";
            if (textBox3.Text == "")
                label4.Text = "not empty";
            else
                label4.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label7.Text = "";
            if (textBox4.Text == "")
                label6.Text = "not empty";
            else
                label6.Text = "";
        }
    }
}
