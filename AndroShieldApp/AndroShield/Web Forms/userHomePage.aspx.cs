﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroApp.Web_Forms
{
    public partial class userHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userEmail.Text = Session["username"].ToString();

            }
        }
        protected void signupNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfilePage.aspx");
        }
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Cookies.Clear();
            Request.Cookies.Clear();

            Session.Abandon();
            Response.Redirect("homePage.aspx");
        }
        protected void uploadApkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("apkUploadPage.aspx");
        }
        protected void viewReportsButton_Click(object sender, EventArgs e)
        {
            Session["userReports"] = userAccountTable.getReportsOfThisUser(Session["username"].ToString());
            Response.Redirect("user'sReportsPage.aspx",false);
        }
    }
}