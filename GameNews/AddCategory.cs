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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void AddCategory_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(string.Empty))
            {
                DialogResult dialogResult = MessageBox.Show("Do u want add " + textBox1.Text + " to category as new category", "Comfirm ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GameNews.DataAccess.CategoryDAO.addNewCategory(textBox1.Text);
                    this.Close();
                }
            }
        }

        
    }
}
