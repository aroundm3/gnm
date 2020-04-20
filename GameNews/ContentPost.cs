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
    public partial class ContentPost : Form
    {
        Post CurrentPost;
        string title;
        public ContentPost()
        {
            InitializeComponent();
        }
        public ContentPost(Post post, string title)
        {
            this.CurrentPost = post;
            this.title = title;
            InitializeComponent();
        }

        private void ContentPost_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\zGou17\Desktop\GameNews\GameNews\GameNews\image\" + CurrentPost.image);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            richTextBox2.Text = title;
            richTextBox1.Text = CurrentPost.content;
        }
    }
}
