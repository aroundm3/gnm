using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GameNews.DataAccess
{
    class DAO
    {
        public static SqlConnection GetConnection()
        {
            //doc thong tin tu file config.
            string ConnectString = ConfigurationManager.ConnectionStrings["GameNews_Str"].ToString();
            SqlConnection Connection = new SqlConnection(ConnectString);
            return Connection;
        }

        public static DataTable GetDataBySQL(string sql)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            DataTable dt = new DataTable();
            Command.Connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();

            dt.Load(Reader);
            Command.Connection.Close();
            return dt;
        }

        public static DataTable GetDataBySQLWithParameters(string sql, params SqlParameter[] parameters)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            DataTable dt = new DataTable();
            Command.Parameters.AddRange(parameters);
            Command.Connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();

            dt.Load(Reader);
            Command.Connection.Close();
            return dt;
        }

        public static int ExecuteSQL(string sql)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            Command.Connection.Open();
            int k = Command.ExecuteNonQuery();
            Command.Connection.Close();
            return k;
        }

        public static int ExecuteSQLWithParameters(string sql, params SqlParameter[] parameters)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            Command.Connection.Open();
            Command.Parameters.AddRange(parameters);
            int k = Command.ExecuteNonQuery();
            Command.Connection.Close();
            return k;
        }
    }

    class AccountDAO
    {
        public static DataTable getAllAccount()
        {
            string sql = "select * from Account ";
            return DAO.GetDataBySQL(sql);
        }

        public static DataTable getAllAccountByNameAndIsWriter(string username, int isWriter)
        {
            string sql = @"  select * from Account where [Account].isAdmin = 0 and [Account].username like N'%" + username + "%' ";
            if(isWriter != 0)
            {
                sql += " and [Account].isWriter = @writer";
                SqlParameter p1 = new SqlParameter("@writer", SqlDbType.Int);
                p1.Value = isWriter;
                return DAO.GetDataBySQLWithParameters(sql, p1);
            }
            return DAO.GetDataBySQL(sql);
        }
        public static DataTable getAccountByUsername(string username)
        {
            string sql = "  select * from Account where [Account].username = @username";
            SqlParameter p1 = new SqlParameter("@username", SqlDbType.VarChar);
            p1.Value = username;
            return DAO.GetDataBySQLWithParameters(sql, p1);

        }
        //update
        public static int activeWriter(string username, int bit)
        {
            string sql = @"update [Account] set [Account].isWriter = @bit where [Account].username = @username ";
            SqlParameter p1 = new SqlParameter("@bit", SqlDbType.Int);
            p1.Value = bit;
            SqlParameter p2 = new SqlParameter("@username", SqlDbType.VarChar);
            p2.Value = username;

            return DAO.ExecuteSQLWithParameters(sql, p1, p2);
        }
        public static int updateImageOfavaterAccount(string imagename, string username)
        {
            string sql = "update [Account] set [Account].avatar = @image where [Account].username = @username ";
            SqlParameter p1 = new SqlParameter("@image", SqlDbType.VarChar);
            p1.Value = imagename;
            SqlParameter p2 = new SqlParameter("@username", SqlDbType.VarChar);
            p2.Value = username;
            return DAO.ExecuteSQLWithParameters(sql, p1, p2);
        }

        public static int updatePasswordAccount(string username, string password)
        {
            string sql = "update [Account] set [Account].password = @password where [Account].username = @username ";
            SqlParameter p1 = new SqlParameter("@password", SqlDbType.VarChar);
            p1.Value = password;
            SqlParameter p2 = new SqlParameter("@username", SqlDbType.VarChar);
            p2.Value = username;
            return DAO.ExecuteSQLWithParameters(sql, p1, p2);
        }

        //delete acc
        public static int deleteAccByUsername(string username)
        {
            string sql = " delete [Account] where Account.username = @name ";
            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
            p1.Value = username;
            return DAO.ExecuteSQLWithParameters(sql, p1);
        }
    }
    class PlatformDAO
    {
        public static DataTable getAllPlatform()
        {
            string sql = "  select * from [Platform] ";
            return DAO.GetDataBySQL(sql);
        }
        //insert
        public static int addNewPlatform(string name)
        {
            string sql = "INSERT INTO [dbo].[Platform] ([platformname]) VALUES (@name) ";
            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
            p1.Value = name;
            return DAO.ExecuteSQLWithParameters(sql, p1);
        }
    }
    class CategoryDAO
    {
        public static DataTable getAllCategory()
        {
            string sql = "select * from [Category] ";
            return DAO.GetDataBySQL(sql);
        }
        //insert
        public static int addNewCategory(string name)
        {
            string sql = "INSERT INTO [dbo].Category (categoryname) VALUES (@name) ";
            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
            p1.Value = name;
            return DAO.ExecuteSQLWithParameters(sql, p1);
        }
    }

    class PostDAO
    {
        public static DataTable getPostByTitileCategoryPlatformAndDatePost(int categoryid, int platformid, DateTime from, DateTime to, string title)
        {
            string sql = @"select [Post].postid, [Account].username, [Category].categoryname, " +
                " [Platform].platformname, [Post].title, [Post].content, [Post].image, " +
                " [Post].upvote, [Post].datecreated " +
                " from Post, Category, [Platform], [Account] " +
                " where [Post].categoryid = [Category].categoryid and [Post].platformid = [Platform].platformid " +
                " and [Post].writtername = [Account].username and [Post].isApprove = 1 and [Post].datecreated between @from and @to " +
                " and [Post].title like N'%" + title + "%' " ;
            SqlParameter p1 = new SqlParameter("@from", SqlDbType.DateTime);
            p1.Value = from;
            SqlParameter p2 = new SqlParameter("@to", SqlDbType.DateTime);
            p2.Value = to;
            if(categoryid != 0)
            {
                sql += " and [Post].categoryid = @categoryid ";
                SqlParameter p3 = new SqlParameter("@categoryid", SqlDbType.Int);
                p3.Value = categoryid;
                if(platformid != 0)
                {
                    sql += " and [Post].platformid = @platformid ";
                    SqlParameter p4 = new SqlParameter("@platformid", SqlDbType.Int);
                    p4.Value = platformid;
                    return DAO.GetDataBySQLWithParameters(sql, p1, p2, p3, p4);
                }
                return DAO.GetDataBySQLWithParameters(sql, p1, p2, p3);
            }
            else
            {
                if (platformid != 0)
                {
                    sql += " and [Post].platformid = @platformid ";
                    SqlParameter p4 = new SqlParameter("@platformid", SqlDbType.Int);
                    p4.Value = platformid;
                    return DAO.GetDataBySQLWithParameters(sql, p1, p2, p4);
                }
            }
            return DAO.GetDataBySQLWithParameters(sql, p1, p2);
        }

        public static DataTable getPostByTitileCategoryPlatformAndDatePostAndAprrove(int categoryid, int platformid, DateTime from, 
            DateTime to, string title, int isApprove, string writername)
        {
            string sql = @"select [Post].postid, [Account].username, [Category].categoryname, " +
                " [Platform].platformname, [Post].title, [Post].content, [Post].image, " +
                " [Post].upvote, [Post].datecreated " +
                " from Post, Category, [Platform], [Account] " +
                " where [Post].categoryid = [Category].categoryid and [Post].platformid = [Platform].platformid " +
                " and [Post].writtername = [Account].username and [Post].isApprove = " + isApprove + " and [Post].datecreated between @from and @to " +
                " and [Post].title like N'%" + title + "%'  and [Post].writtername = '" + writername + "'";
            SqlParameter p1 = new SqlParameter("@from", SqlDbType.DateTime);
            p1.Value = from;
            SqlParameter p2 = new SqlParameter("@to", SqlDbType.DateTime);
            p2.Value = to;
            if (categoryid != 0)
            {
                sql += " and [Post].categoryid = @categoryid ";
                SqlParameter p3 = new SqlParameter("@categoryid", SqlDbType.Int);
                p3.Value = categoryid;
                if (platformid != 0)
                {
                    sql += " and [Post].platformid = @platformid ";
                    SqlParameter p4 = new SqlParameter("@platformid", SqlDbType.Int);
                    p4.Value = platformid;
                    return DAO.GetDataBySQLWithParameters(sql, p1, p2, p3, p4);
                }
                return DAO.GetDataBySQLWithParameters(sql, p1, p2, p3);
            }
            else
            {
                if (platformid != 0)
                {
                    sql += " and [Post].platformid = @platformid ";
                    SqlParameter p4 = new SqlParameter("@platformid", SqlDbType.Int);
                    p4.Value = platformid;
                    return DAO.GetDataBySQLWithParameters(sql, p1, p2, p4);
                }
            }
            return DAO.GetDataBySQLWithParameters(sql, p1, p2);
        }


        public static DataTable getAllPostNeedApprove()
        {
            string sql = @"select [Post].postid, [Account].username, [Category].categoryname, [Post].isApprove, " +
                " [Platform].platformname, [Post].title, [Post].content, [Post].image, " +
                " [Post].upvote, [Post].datecreated " +
                " from Post, Category, [Platform], [Account] " +
                " where [Post].categoryid = [Category].categoryid and [Post].platformid = [Platform].platformid " +
                " and [Post].writtername = [Account].username and [Post].isApprove = 0 ";
            return DAO.GetDataBySQL(sql);
        }

        public static DataTable getAllPostsByWriter(string writername)
        {
            string sql = @"select [Post].postid, [Account].username, [Category].categoryname, [Post].isApprove, " +
                " [Platform].platformname, [Post].title, [Post].content, [Post].image, " +
                " [Post].upvote, [Post].datecreated " +
                " from Post, Category, [Platform], [Account] " +
                " where [Post].categoryid = [Category].categoryid and [Post].platformid = [Platform].platformid " +
                " and [Post].writtername = [Account].username and [Post].isApprove = 1 and [Post].writtername = @name ";
            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
            p1.Value = writername;
            return DAO.GetDataBySQLWithParameters(sql, p1);
        }

        public static DataTable getPostContentAndImageByPostID(int id)
        {
            string sql = "select [Post].content, [Post].image from [Post] where postid = @id ";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;
            return DAO.GetDataBySQLWithParameters(sql, p1);
        }
        public static int deletePostByID(int id)
        {
            string sql = "delete [Post] where [Post].postid = @id ";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;
            return DAO.ExecuteSQLWithParameters(sql, p1);
        }
        //update
        public static int approvePostbyID(int id)
        {
            string sql = "UPDATE [dbo].[Post] SET [isApprove] = 1 WHERE [Post].postid = @id";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;
            return DAO.ExecuteSQLWithParameters(sql, p1);
        }

        public static int updatePostByID(int id, string title, string content, string imagepath)
        {
            string sql = "UPDATE [dbo].[Post] SET [title] = @title ,[content] =  @content ," +
                "[image] =  @image , [isApprove] = 0 WHERE [Post].postid = @id ";
            SqlParameter p1 = new SqlParameter("@title", SqlDbType.VarChar);
            p1.Value = title;
            SqlParameter p2 = new SqlParameter("@content", SqlDbType.VarChar);
            p2.Value = content;
            SqlParameter p3 = new SqlParameter("@image", SqlDbType.VarChar);
            p3.Value = imagepath;
            SqlParameter p4 = new SqlParameter("@id", SqlDbType.Int);
            p4.Value = id;

            return DAO.ExecuteSQLWithParameters(sql, p1, p2, p3, p4);
        }
        //insert
        public static int addPost(string title, string writername, string content, string image, int platformid, int categoryid)
        {
            string sql = "INSERT INTO [dbo].[Post] ([title] , [writtername] , [content] , [image]  , [upvote] , " +
                " [platformid] , [categoryid] , [datecreated] , [isApprove]) " +
                " VALUES ( @title, @writername, @content, @image, 0, @platformid, @categoryid, GETDATE(), 0 )";
            SqlParameter p1 = new SqlParameter("@title", SqlDbType.VarChar);
            p1.Value = title;
            SqlParameter p2 = new SqlParameter("@writername", SqlDbType.VarChar);
            p2.Value = writername;
            SqlParameter p3 = new SqlParameter("@content", SqlDbType.VarChar);
            p3.Value = content;
            SqlParameter p4 = new SqlParameter("@image", SqlDbType.VarChar);
            p4.Value = image;
            SqlParameter p5 = new SqlParameter("@platformid", SqlDbType.Int);
            p5.Value = platformid;
            SqlParameter p6 = new SqlParameter("@categoryid", SqlDbType.Int);
            p6.Value = categoryid;

            return DAO.ExecuteSQLWithParameters(sql, p1, p2, p3, p4, p5, p6);
        }
    }
}
