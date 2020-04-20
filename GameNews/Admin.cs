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
    public partial class Admin : Form
    {
        Account currentAccount;
        public Admin()
        {
            InitializeComponent();
        }
        public Admin(Account account)
        {
            this.currentAccount = account;
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "platformname";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = GameNews.Logic.PlatformList.getAllPlatform();
            comboBox1.SelectedIndex = 0;

            comboBox2.DisplayMember = "categoryname";
            comboBox2.ValueMember = "id";
            comboBox2.DataSource = GameNews.Logic.CategoryList.getAllCategory();
            comboBox2.SelectedIndex = 0;
            //dtg1
            string[] colText = { "UserName", "Email" };
            string[] colname = { "username", "email" };
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowTemplate.Height = 50;
            for (int i = 0; i < colname.Length; i++)
            {
                dataGridView1.Columns.Add(colname[i], colText[i]);
                dataGridView1.Columns[colname[i]].DataPropertyName = colname[i];
                dataGridView1.Columns[colname[i]].Width = 150;
            }
            DataGridViewCheckBoxColumn isWriter = new DataGridViewCheckBoxColumn();
            isWriter.HeaderText = "Writer";
            isWriter.Name = "Writer";
            dataGridView1.Columns.Add(isWriter);
            isWriter.Width = 150;
            isWriter.DataPropertyName = "isWriter";

            DataGridViewButtonColumn detail = new DataGridViewButtonColumn();
            detail.HeaderText = "Detail";
            detail.Name = "Detail";
            detail.Text = "View";
            detail.UseColumnTextForButtonValue = true;
            detail.Width = 100;
            dataGridView1.Columns.Add(detail);

            DataGridViewButtonColumn remove = new DataGridViewButtonColumn();
            remove.HeaderText = "Remove";
            remove.Name = "Remove";
            remove.Text = "remove";
            remove.UseColumnTextForButtonValue = true;
            remove.Width = 100;
            dataGridView1.Columns.Add(remove);

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            //drg2
            string[] colText2 = { "Post ID", "Writer", "Title", "Upvote", "Category", "Platform", "Date Post" };
            string[] colname2 = { "postid", "username", "title", "upvote", "categoryname", "platformname", "datecreated" };
            dataGridView2.Columns.Clear();
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowTemplate.Height = 50;
            for (int i = 0; i < colname2.Length; i++)
            {
                if (colname2[i] == "title")
                {
                    dataGridView2.Columns.Add(colname2[i], colText2[i]);
                    dataGridView2.Columns[colname2[i]].DataPropertyName = colname2[i];
                    dataGridView2.Columns[colname2[i]].Width = 250;
                }
                else
                {
                    dataGridView2.Columns.Add(colname2[i], colText2[i]);
                    dataGridView2.Columns[colname2[i]].DataPropertyName = colname2[i];
                    dataGridView2.Columns[colname2[i]].Width = 90;
                }
            }

            DataGridViewButtonColumn seeContent = new DataGridViewButtonColumn();
            seeContent.HeaderText = "Content";
            seeContent.Name = "Content";
            seeContent.Text = "detail";
            seeContent.UseColumnTextForButtonValue = true;
            seeContent.Width = 80;
            dataGridView2.Columns.Add(seeContent);

            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Remove";
            delete.Name = "delete";
            delete.Text = "remove";
            delete.UseColumnTextForButtonValue = true;
            delete.Width = 80;
            dataGridView2.Columns.Add(delete);

            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            //dtg3
            string[] colText3 = { "Post ID", "Writer", "Title", "Upvote", "Category", "Platform", "Date Post" };
            string[] colname3 = { "postid", "username", "title", "upvote", "categoryname", "platformname", "datecreated" };
            dataGridView3.Columns.Clear();
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.RowTemplate.Height = 50;
            for (int i = 0; i < colname3.Length; i++)
            {
                if (colname3[i] == "title")
                {
                    dataGridView3.Columns.Add(colname3[i], colText3[i]);
                    dataGridView3.Columns[colname3[i]].DataPropertyName = colname3[i];
                    dataGridView3.Columns[colname3[i]].Width = 170;
                }
                else
                {
                    dataGridView3.Columns.Add(colname3[i], colText3[i]);
                    dataGridView3.Columns[colname3[i]].DataPropertyName = colname3[i];
                    dataGridView3.Columns[colname3[i]].Width = 90;
                }
            }

            DataGridViewButtonColumn seeContent2 = new DataGridViewButtonColumn();
            seeContent2.HeaderText = "Content";
            seeContent2.Name = "Content";
            seeContent2.Text = "detail";
            seeContent2.UseColumnTextForButtonValue = true;
            seeContent2.Width = 80;
            dataGridView3.Columns.Add(seeContent2);

            DataGridViewButtonColumn delete2 = new DataGridViewButtonColumn();
            delete2.HeaderText = "Remove";
            delete2.Name = "delete";
            delete2.Text = "remove";
            delete2.UseColumnTextForButtonValue = true;
            delete2.Width = 80;
            dataGridView3.Columns.Add(delete2);

            DataGridViewCheckBoxColumn Approve = new DataGridViewCheckBoxColumn();
            Approve.HeaderText = "Approve";
            Approve.Name = "Approve";
            dataGridView3.Columns.Add(Approve);
            Approve.Width = 80;
            Approve.DataPropertyName = "isApprove";

            foreach (DataGridViewColumn col in dataGridView3.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            loadData();
        }
        void loadData()
        {
            int platformID = Convert.ToInt32(comboBox1.SelectedValue);
            int categoryID = Convert.ToInt32(comboBox2.SelectedValue);
            DateTime from = dateTimePicker1.Value;
            DateTime to = dateTimePicker2.Value;
            string title = textBox2.Text;

            if (currentAccount != null)
            {
                label2.Text = currentAccount.username;
                label3.Text = currentAccount.username;
                label5.Text = currentAccount.username;
                pictureBox1.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + currentAccount.avatar);
                pictureBox2.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + currentAccount.avatar);
                pictureBox3.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + currentAccount.avatar);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            dataGridView1.DataSource = GameNews.Logic.AccountList.getAllAccountByNameAndIsWriter(textBox1.Text,
                Convert.ToInt32(checkBox1.Checked));

            dataGridView2.DataSource = GameNews.Logic.PostList.getPostByTitileCategoryPlatformAndDatePost(categoryID, platformID, from, to, title);
            dataGridView3.DataSource = GameNews.Logic.PostList.getAllPostNeedApprove();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                try
                {
                    string usernameToUpdate = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Detail")
                    {
                        ProfileOfanother form1 = new ProfileOfanother(GameNews.Logic.Account.getAccountByUsername(usernameToUpdate));
                        form1.Show(); 
                    }
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Remove")
                    {
                        DialogResult dialogResult = MessageBox.Show("Do u want remove " + usernameToUpdate, "Confirm ", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GameNews.Logic.Account.deleteAccByUsername(usernameToUpdate);
                            loadData();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                try
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Writer")
                    {
                        string usernameToUpdate = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                        if ((bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue)
                        {
                            DialogResult dialogResult = MessageBox.Show("Do u want inactive Writer of " + usernameToUpdate, "Confirm ", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                GameNews.Logic.Account.activeWriter(usernameToUpdate, 0);
                                loadData();
                            }
                            else
                                loadData();
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Do u want active Writer of " + usernameToUpdate, "Confirm ", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                GameNews.Logic.Account.activeWriter(usernameToUpdate, 1);
                                loadData();
                            }
                            else
                                loadData();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profile form1 = new Profile(currentAccount);
            form1.FormClosed += formClose;
            form1.Show();
        }

        private void formClose(object sender, EventArgs e)
        {
            Admin_Load(sender, e);
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            AddPlatform form1 = new AddPlatform();
            form1.FormClosed += formClose;
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddCategory form1 = new AddCategory();
            form1.FormClosed += formClose;
            form1.Show();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0)
                {
                    int postid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["postid"].Value);
                    if (dataGridView2.Columns[e.ColumnIndex].Name == "Content")
                    {
                        ContentPost form1 = new ContentPost(GameNews.Logic.PostList.getPostContentAndImageByPostID(postid),
                           dataGridView2.Rows[e.RowIndex].Cells["title"].Value.ToString());
                        form1.Show();
                    }
                    if (dataGridView2.Columns[e.ColumnIndex].Name == "delete")
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
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }


        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int postid = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells["postid"].Value);
                if (dataGridView3.Columns[e.ColumnIndex].Name == "Content")
                {
                    ContentPost form1 = new ContentPost(GameNews.Logic.PostList.getPostContentAndImageByPostID(postid),
                           dataGridView3.Rows[e.RowIndex].Cells["title"].Value.ToString());
                    form1.Show();
                }
                if (dataGridView3.Columns[e.ColumnIndex].Name == "delete")
                {
                    DialogResult dialogResult = MessageBox.Show("Do u want remove this post from the list", "Confirm ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        GameNews.Logic.Post.deletePostByID(postid);
                        loadData();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                try
                {
                    if (dataGridView3.Columns[e.ColumnIndex].Name == "Approve")
                    {
                        int postid = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells["postid"].Value);
                        if (!(bool)dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue)
                        {
                            DialogResult dialogResult = MessageBox.Show("Do u want approve this post ", "Confirm", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                GameNews.Logic.Post.approvePostbyID(postid);
                                loadData();
                            }
                            else
                                loadData();
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
}
