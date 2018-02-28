﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroShield.Web_Forms
{
    public partial class incorrectCredentialsPage : System.Web.UI.Page
    {
        databaseLayer androDatabase;
        userAccountTable userAccount;
        protected void Page_Load(object sender, EventArgs e)
        {
            userAccount = new userAccountTable();
            androDatabase = new databaseLayer();
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text.ToString();
            string password = passwordTxt.Text.ToString();

            userAccount = userAccountTable.userLogin(email, password);
            if (userAccount != null)
            {
                Response.Redirect("userHomePage.aspx");
            }
            else
            {
                Response.Redirect("incorrectCredentialsPage.aspx");
            }

        }
    }
}