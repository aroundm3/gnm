using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GameNews.Logic
{
    public class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool isAdmin { get; set; }
        public string avatar { get; set; }
        public bool isWriter { get; set; }

        public Account()
        {

        }
        public Account(string username, string password, string email, bool isAdmin, string avatar, bool isWriter)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.isAdmin = isAdmin;
            this.avatar = avatar;
            this.isWriter = isWriter;
        }

        public static int activeWriter(string username, int bit)
        {
            return FakeNews.DataAccess.AccountDAO.activeWriter(username, bit);
        }

        public static int updateImageOfavaterAccount(string imagename, string username)
        {
            return FakeNews.DataAccess.AccountDAO.updateImageOfavaterAccount(imagename, username);
        }

        public static int updatePasswordAccount(string username, string password)
        {
            return FakeNews.DataAccess.AccountDAO.updatePasswordAccount(username, password);
        }

        public static Account getAccountByUsername(string username)
        {
            Account account = new Account();
            DataTable dt = FakeNews.DataAccess.AccountDAO.getAccountByUsername(username);
            foreach (DataRow dr in dt.Rows)
            {
                account = new Account(
                    dr["username"].ToString(),
                    dr["password"].ToString(),
                    dr["email"].ToString(),
                    Convert.ToBoolean(dr["isAdmin"]),
                    dr["avatar"].ToString(),
                    Convert.ToBoolean(dr["isWriter"]));
            }
            return account;
        }

        //delete
        public static int deleteAccByUsername(string username)
        {
            return FakeNews.DataAccess.AccountDAO.deleteAccByUsername(username);
        }
    }

    class AccountList
    {
        public static List<Account> getAllAccount()
        {
            List<Account> accounts = new List<Account>();
            DataTable dt = FakeNews.DataAccess.AccountDAO.getAllAccount();
            foreach(DataRow dr in dt.Rows)
            {
                Account account = new Account(
                    dr["username"].ToString(),
                    dr["password"].ToString(),
                    dr["email"].ToString(),
                    Convert.ToBoolean(dr["isAdmin"]),
                    dr["avatar"].ToString(),
                    Convert.ToBoolean(dr["isWriter"]));
                accounts.Add(account);
                    
            }
            return accounts;
        }

        public static List<Account> getAllAccountByNameAndIsWriter(string username, int isWriter)
        {
            List<Account> accounts = new List<Account>();
            DataTable dt = FakeNews.DataAccess.AccountDAO.getAllAccountByNameAndIsWriter( username,  isWriter);
            foreach (DataRow dr in dt.Rows)
            {
                Account account = new Account(
                    dr["username"].ToString(),
                    dr["password"].ToString(),
                    dr["email"].ToString(),
                    Convert.ToBoolean(dr["isAdmin"]),
                    dr["avatar"].ToString(),
                    Convert.ToBoolean(dr["isWriter"]));
                accounts.Add(account);

            }
            return accounts;
        }

        
    }
}
