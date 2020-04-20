using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GameNews.Logic
{
    public class Post
    {
        public int postid { get; set; }
        public string title { get; set; }
        public  string writername { get; set; }
        public string content { get; set; }
        public string image { get; set; }
        public string videourl { get; set; }
        public int upvote { get; set; }
        public int platformid { get; set; }
        public int categoryid { get; set; }
        public DateTime datecreate { get; set; }
        public bool isApprove { get; set; }

        public Post()
        {

        }

        public Post (int postid, string title, string writername, string content, string image, string videourl, int upvote, int platformid, int categoryid,
            DateTime datecreate, bool isApprove)
        {

        }

        public Post(string content, string image)
        {
            this.content = content;
            this.image = image;
        }
        //delete
        public static int deletePostByID(int id)
        {
            return GameNews.DataAccess.PostDAO.deletePostByID(id);
        }
        //update Approve
        public static int approvePostbyID(int id)
        {
            return GameNews.DataAccess.PostDAO.approvePostbyID(id);
        }
        //
        public static int updatePostByID(int id, string title, string content, string imagepath)
        {
            return GameNews.DataAccess.PostDAO.updatePostByID(id, title, content, imagepath);
        }
        //insert
        public static int addPost(string title, string writername, string content, string image, int platformid, int categoryid)
        {
            return GameNews.DataAccess.PostDAO.addPost(title, writername, content, image, platformid, categoryid);
        }
    }

    class PostList
    {
        public static DataTable getPostByTitileCategoryPlatformAndDatePost(int categoryid, int platformid, DateTime from, DateTime to, string title)
        {
            return GameNews.DataAccess.PostDAO.getPostByTitileCategoryPlatformAndDatePost(categoryid, platformid, from, to, title);
        }
        public static DataTable getPostByTitileCategoryPlatformAndDatePostAndAprrove(int categoryid, int platformid, DateTime from,
            DateTime to, string title, int isApprove, string writername)
        {
            return GameNews.DataAccess.PostDAO.getPostByTitileCategoryPlatformAndDatePostAndAprrove(categoryid, platformid, from, to, title, isApprove, writername);

        }
        public static DataTable getAllPostNeedApprove()
        {
            return GameNews.DataAccess.PostDAO.getAllPostNeedApprove();
        }

        public static DataTable getAllPostsByWriter(string writername)
        {
            return GameNews.DataAccess.PostDAO.getAllPostsByWriter(writername);
        }

        public static Post getPostContentAndImageByPostID(int id)
        {
            Post post = new Post();
            DataTable dt = GameNews.DataAccess.PostDAO.getPostContentAndImageByPostID(id);
            foreach(DataRow dr in dt.Rows)
            {
                post = new Post(dr["content"].ToString(), dr["image"].ToString());
            }
            return post;
        }
    }
}
