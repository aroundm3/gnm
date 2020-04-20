using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeNews
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int postid = Convert.ToInt32(Request.QueryString["id"]);
            postCt.DataSource = FakeNews.DataAccess.PostDAO.getPostContentAndImageByPostID22(postid);
            postCt.DataBind();
        }
    }
}