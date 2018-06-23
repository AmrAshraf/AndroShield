using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroApp.Web_Forms
{
    public partial class aboutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"] != null)
            {
                signupNav.Text = "My Profile";
                userEmail.Text = Session["username"].ToString();
                userEmail.Visible = true;
                welcomeLabel.Visible = true;
            }
            else
            {
                logoutButton.Visible = false;
                userEmail.Visible = false;
                welcomeLabel.Visible = false;
                signupNav.Text = "Sign Up";
            }
        }
        protected void signupNav_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("userProfilePage.aspx");
                signupNav.Text = "Profile";
                userEmail.Visible = true;
            }
            else
            {
                Response.Redirect("signUpPage.aspx");
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Cookies.Clear();
            Request.Cookies.Clear();

            Session.Abandon();
            Response.Redirect("homePage.aspx");

        }
    }
}