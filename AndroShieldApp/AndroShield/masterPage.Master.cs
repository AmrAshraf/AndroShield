using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroShield
{
    public partial class masterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aboutNav_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("aboutPage.aspx");
        }

        //protected void logoWord_ServerClick(object sender, EventArgs e)
        //{
        //    if (Session["username"] == null || Session["username"].ToString() == "")
        //    {
        //        Response.Redirect("homePage.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("userHomePage.aspx");
        //    }

        //}

        protected void navAbout_Click(object sender, EventArgs e)
        {
            Response.Redirect("aboutPage.aspx");
        }

        protected void logo_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("homePage.aspx");
            }
            else
            {
                Response.Redirect("userHomePage.aspx");
            }
        }

        protected void logoWord_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("homePage.aspx");
            }
            else
            {
                Response.Redirect("userHomePage.aspx");
            }
        }
    }
}