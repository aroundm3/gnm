using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GameNews.Logic;

namespace FakeNews
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                DataTable dt = FakeNews.DataAccess.PlatformDAO.getAllPlatform();
                platformBar.DataSource = dt;
                platformBar.DataBind();
            }
            loadData();
        }

        void loadData()
        {

            postList.DataSource = FakeNews.DataAccess.PostDAO.getPostByTitileCategoryPlatformAndDatePost(0, 0, Convert.ToDateTime("2019/1/1"),
                DateTime.Now, "");
            postList.DataBind();
        }
    }
}