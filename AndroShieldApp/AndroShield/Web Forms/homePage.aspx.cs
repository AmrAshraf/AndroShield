using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AndroApp
{
    public partial class homepage : System.Web.UI.Page
    {
        databaseLayer androDatabase;
        userAccountTable userAccount;
        protected void Page_Load(object sender, EventArgs e)
        {
            userAccount = new userAccountTable();
            androDatabase = new databaseLayer();
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("signUpPage.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text.ToString();
            string password = passwordTxt.Text.ToString();

            userAccount = userAccountTable.userLogin(email, password);
            if(userAccount!=null)
            {
                Session["username"] = email;
                Session["userAccount"] = userAccount;
                Response.Redirect("userHomePage.aspx");
            }
            else
            {
                Response.Redirect("incorrectCredentialsPage.aspx");
            }
        }

        protected void signupButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("signUpPage.aspx");
        }

        protected void navSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("signUpPage.aspx");
        }
    }
}