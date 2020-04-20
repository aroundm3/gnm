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
    public partial class ProfileOfanother : Form
    {
        Account currentAccount;
        public ProfileOfanother()
        {
            InitializeComponent();
        }

        public ProfileOfanother(Account account)
        {
            this.currentAccount = account;
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + currentAccount.avatar);
            textBox1.Text = currentAccount.username;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox2.Text = currentAccount.email;

            if(currentAccount.isWriter)
            {
                label3.Visible = true;
                label4.Visible = true;
            }
            else
            {
                label3.Visible = false;
                label4.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PostsOfWriter form1 = new PostsOfWriter(currentAccount);
            form1.Show();
        }
    }


}
