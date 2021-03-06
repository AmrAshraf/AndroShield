﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroApp.Web_Forms
{
    public partial class userProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
                Response.Redirect("homePage.aspx");

            Session["currentUser"] = userAccountTable.findUserByEmail(Session["username"].ToString());
            userEmail.Text = Session["username"].ToString();
            Session["oldPassword"] = ((userAccountTable)Session["currentUser"]).password;
            if (!IsPostBack)
            {
                firstNameTxt.Text = ((userAccountTable)Session["currentUser"]).firstName;
                lastNameTxt.Text = ((userAccountTable)Session["currentUser"]).lastName;
            }
            if((bool)Session["thirdPartyLogin"])
            {
                passwordTxt.Enabled = false;
                newPassword.Enabled = false;
                newRepeat.Enabled = false;
            }
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Clear();
            Request.Cookies.Clear();

            Session.Abandon();
            Response.Redirect("homePage.aspx");
        }

        protected void signupNav2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfilePage.aspx");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Session["fname"] = ((userAccountTable)Session["currentUser"]).firstName;
            Session["lname"] = ((userAccountTable)Session["currentUser"]).lastName;
            Session["newpass"] = Session["oldPassword"];

            if (passwordTxt.Text == "")
            {
                Session["newpass"] = Session["oldPassword"];
            }
            else if (Session["oldPassword"].ToString()!= passwordTxt.Text)
            {
                incorrectPasswordMsg.Visible = true;
            }
            else
            {
                Session["newpass"] = newPassword.Text;
            }
            if (firstNameTxt.Text!= ((userAccountTable)Session["currentUser"]).firstName && firstNameTxt.Text!="")
            {
                Session["fname"] = firstNameTxt.Text;
            }
            if (lastNameTxt.Text != ((userAccountTable)Session["currentUser"]).lastName && lastNameTxt.Text != "")
            {
                Session["lname"] = lastNameTxt.Text;
            }
            ((userAccountTable)Session["currentUser"]).updateUser(DateTime.Now, Session["newpass"].ToString(), Session["username"].ToString(), Session["fname"].ToString(), Session["lname"].ToString());

            Session.Contents.Remove("fname");
            Session.Contents.Remove("lname");
            Session.Contents.Remove("newpass");
            Session.Contents.Remove("oldPassword");
        }

        protected void resetBtn_Click(object sender, EventArgs e)
        {
            firstNameTxt.Text = ((userAccountTable)Session["currentUser"]).firstName;
            lastNameTxt.Text = ((userAccountTable)Session["currentUser"]).lastName;
        }
    }
}