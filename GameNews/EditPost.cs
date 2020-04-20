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
    public partial class EditPost : Form
    {
        Post CurrentPost;
        string title;
        int postid;
        string imagePath = "";
        public EditPost()
        {
            InitializeComponent();
        }

        public EditPost(Post post, string title, int id)
        {
            this.CurrentPost = post;
            this.title = title;
            this.postid = id;
            InitializeComponent();
        }

        private void EditPost_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + CurrentPost.image);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            richTextBox2.Text = title;
            richTextBox1.Text = CurrentPost.content;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
            }
            imagePath = opnfd.FileName.Substring(opnfd.FileName.LastIndexOf(@"\") + 1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string title = richTextBox2.Text;
            string content = richTextBox1.Text;
            DialogResult dialogResult = MessageBox.Show("Do u want accept change of this post, your post will be waited to approve", 
                "Confirm ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!imagePath.Equals(string.Empty))
                    GameNews.Logic.Post.updatePostByID(postid, title, content, imagePath);
                else
                    GameNews.Logic.Post.updatePostByID(postid, title, content, CurrentPost.image);
                this.Close();
            }
            
        }
    }
}
