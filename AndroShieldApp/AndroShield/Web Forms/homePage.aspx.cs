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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Timeout = 80;
                androDatabase = new databaseLayer();
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("signUpPage.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["tempUsername"] = emailTxt.Text.ToString();
            Session["password"] = passwordTxt.Text.ToString();

            Session["userAccount"] = userAccountTable.userLogin(Session["tempUsername"].ToString(), Session["password"].ToString());
            if(Session["userAccount"] != null)
            {
                Session["username"] = Session["tempUsername"];
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