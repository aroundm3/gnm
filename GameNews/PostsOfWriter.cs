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
    public partial class PostsOfWriter : Form
    {
        Account currentAccount;
        public PostsOfWriter()
        {
            InitializeComponent();
        }

        public PostsOfWriter(Account account)
        {
            this.currentAccount = account;
            InitializeComponent();
        }

        void loadData()
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + currentAccount.avatar);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label2.Text = currentAccount.username;
            label4.Text = currentAccount.username;
            dataGridView1.DataSource = GameNews.Logic.PostList.getAllPostsByWriter(currentAccount.username);
        }

        private void PostsOfWriter_Load(object sender, EventArgs e)
        {
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
                    dataGridView1.Columns[colname2[i]].Width = 170;
                }
                else
                {
                    dataGridView1.Columns.Add(colname2[i], colText2[i]);
                    dataGridView1.Columns[colname2[i]].DataPropertyName = colname2[i];
                    dataGridView1.Columns[colname2[i]].Width = 80;
                }
            }
            DataGridViewButtonColumn seeContent = new DataGridViewButtonColumn();
            seeContent.HeaderText = "Content";
            seeContent.Name = "Content";
            seeContent.Text = "detail";
            seeContent.UseColumnTextForButtonValue = true;
            seeContent.Width = 80;
            dataGridView1.Columns.Add(seeContent);

            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0)
                {
                    int postid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["postid"].Value);
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Content")
                    {
                        ContentPost form1 = new ContentPost(GameNews.Logic.PostList.getPostContentAndImageByPostID(postid),
                           dataGridView1.Rows[e.RowIndex].Cells["title"].Value.ToString());
                        form1.Show();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
