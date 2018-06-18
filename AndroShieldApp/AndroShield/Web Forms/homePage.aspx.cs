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

                if (Request.UrlReferrer == null && Request.Cookies["androUsername"] != null && Request.Cookies["androPassword"]!=null)
                {
                    Session["tempUsername"] = Request.Cookies["androUsername"].Value;
                    Session["password"] = Request.Cookies["androPassword"].Value;
                    Session["userAccount"] = userAccountTable.userLogin(Request.Cookies["androUsername"].Value.ToString(), Request.Cookies["androPassword"].Value.ToString());
                    userAccountTable test = (userAccountTable)Session["userAccount"];
                    handleLogin();
                }

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
            handleLogin();

        }
        protected void handleLogin()
        {

            if (Session["userAccount"] != null)
            {
                Session["username"] = Session["tempUsername"].ToString();
                Session["thirdPartyLogin"] = false;

                if (rememberMeChck.Checked)
                {
                    Response.Cookies["androUsername"].Value = Session["username"].ToString();
                    Response.Cookies["androPassword"].Value = Session["password"].ToString();

                    Response.Cookies["androUsername"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["androPassword"].Expires = DateTime.Now.AddDays(15);
                }

                else
                {
                    Response.Cookies["androUsername"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["androPassword"].Expires = DateTime.Now.AddDays(-1);
                }
                Response.Redirect("userHomePage.aspx");
            }
            else
            {
                Response.Redirect("incorrectCredentialsPage.aspx");
            }
            Session.Contents.Remove("tempUsername");

        }
        protected void signupButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("signUpPage.aspx");
        }

        protected void navSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("signUpPage.aspx");
        }

        protected void fbButton_Click(object sender, EventArgs e)
        {
            var url = "https://www.facebook.com/dialog/oauth?client_id=2277532892260615&response_type=code&scope=email&redirect_uri=https://localhost:44302/FB/facebookRedirect.aspx/";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "dsadas", "window.location.href('" + url + "');", true);
        }
    }
}