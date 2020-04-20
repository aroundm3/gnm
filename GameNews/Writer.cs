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
    public partial class Writer : Form
    {
        Account currentAccount;
        string imagePath = "";
        public Writer()
        {
            InitializeComponent();
        }
        public Writer(Account account)
        {
            this.currentAccount = account;
            InitializeComponent();
        }

        private void Writer_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "platformname";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = GameNews.Logic.PlatformList.getAllPlatform();
            comboBox1.SelectedIndex = 0;

            comboBox2.DisplayMember = "categoryname";
            comboBox2.ValueMember = "id";
            comboBox2.DataSource = GameNews.Logic.CategoryList.getAllCategory();
            comboBox2.SelectedIndex = 0;
            
            comboBox3.DisplayMember = "platformname";
            comboBox3.ValueMember = "id";
            comboBox3.DataSource = GameNews.Logic.PlatformList.getAllPlatform();
            comboBox3.SelectedIndex = 0;

            comboBox4.DisplayMember = "categoryname";
            comboBox4.ValueMember = "id";
            comboBox4.DataSource = GameNews.Logic.CategoryList.getAllCategory();
            comboBox4.SelectedIndex = 0;

            //dgv1
            string[] colText2 = { "Post ID", "Writer", "Title", "Upvote", "Category", "Platform", "Date Post" };
            string[] colname2 = { "postid", "username", "title", "upvote", "categoryname", "platformname", "datecreated" };
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowTemplate.Height = 50;
            for (int i = 0; i < colname2.Length; i++)
            {
                if (colname2[i] == "title")
                {
                    dataGridView1.Columns.Add(colname2[i], colText2[i]);
                    dataGridView1.Columns[colname2[i]].DataPropertyName = colname2[i];
                    dataGridView1.Columns[colname2[i]].Width = 250;
                }
                else
                {
                    dataGridView1.Columns.Add(colname2[i], colText2[i]);
                    dataGridView1.Columns[colname2[i]].DataPropertyName = colname2[i];
                    dataGridView1.Columns[colname2[i]].Width = 90;
                }
            }

            DataGridViewButtonColumn seeContent = new DataGridViewButtonColumn();
            seeContent.HeaderText = "Content";
            seeContent.Name = "Content";
            seeContent.Text = "detail";
            seeContent.UseColumnTextForButtonValue = true;
            seeContent.Width = 80;
            dataGridView1.Columns.Add(seeContent);

            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Remove";
            delete.Name = "delete";
            delete.Text = "remove";
            delete.UseColumnTextForButtonValue = true;
            delete.Width = 80;
            dataGridView1.Columns.Add(delete);

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            loadData();
        }

        void loadData()
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            int platformID = Convert.ToInt32(comboBox1.SelectedValue);
            int categoryID = Convert.ToInt32(comboBox2.SelectedValue);
            DateTime from = dateTimePicker1.Value;
            DateTime to = dateTimePicker2.Value;
            string title = textBox2.Text;

            pictureBox1.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + currentAccount.avatar);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + currentAccount.avatar);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            label2.Text = currentAccount.username;
            label5.Text = currentAccount.username;

            dataGridView1.DataSource = GameNews.Logic.PostList.getPostByTitileCategoryPlatformAndDatePostAndAprrove(categoryID, platformID,
                from, to, title, Convert.ToInt32(checkBox1.Checked), currentAccount.username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profile form1 = new Profile(currentAccount);
            form1.FormClosed += formClose;
            form1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Profile form1 = new Profile(currentAccount);
            form1.FormClosed += formClose;
            form1.Show();
        }
        private void formClose(object sender, EventArgs e)
        {
            Writer_Load(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                int postid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["postid"].Value);
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Content")
                {
                    EditPost form1 = new EditPost(GameNews.Logic.PostList.getPostContentAndImageByPostID(postid),
                       dataGridView1.Rows[e.RowIndex].Cells["title"].Value.ToString(), 
                       Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["postid"].Value));
                    form1.FormClosed += formClose;
                    form1.Show();
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "delete")
                {
                    DialogResult dialogResult = MessageBox.Show("Do u want remove this post from the list", "Confirm ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        GameNews.Logic.Post.deletePostByID(postid);
                        loadData();
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do u want add, your post will be waited to approve", "Confirm ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                    string content = richTextBox1.Text;
                    string title = richTextBox2.Text;
                    string writername = currentAccount.username;
                    int platformID = Convert.ToInt32(comboBox3.SelectedValue);
                    int categoryID = Convert.ToInt32(comboBox4.SelectedValue);
                    if (content != "" && title != "" && writername != "" && platformID != 0 && categoryID != 0 && imagePath != "")
                    {
                        GameNews.Logic.Post.addPost(title, writername, content, imagePath, platformID, categoryID);
                        imagePath = "";
                        MessageBox.Show("Add succsess, waiting for approve");
                        Writer_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Must fill All Title, Content, Image, category and plstform");
                    }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(opnfd.FileName);
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            imagePath = opnfd.FileName.Substring(opnfd.FileName.LastIndexOf(@"\") + 1);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Writer_Load(sender, e);
        }

    }
}
