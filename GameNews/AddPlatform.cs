using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameNews
{
    public partial class AddPlatform : Form
    {
        public AddPlatform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(string.Empty))
            {
                DialogResult dialogResult = MessageBox.Show("Do u want add " + textBox1.Text + " to platform as new platform", "Comfirm ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GameNews.DataAccess.PlatformDAO.addNewPlatform(textBox1.Text);
                    this.Close();
                }
            }
            
        }

        private void AddPlatform_Load(object sender, EventArgs e)
        {
            label6.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(string.Empty))
            {
                label6.Text = "not empty";
            }
            else
                label6.Text = "";
        }
    }
}
