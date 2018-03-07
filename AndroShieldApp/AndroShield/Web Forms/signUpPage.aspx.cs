using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroApp.Web_Forms
{
    public partial class signUpPage : System.Web.UI.Page
    {
        userAccountTable userAccount;
        protected void Page_Load(object sender, EventArgs e)
        {
            userAccount = new userAccountTable();
        }

        protected void signUpButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTxt.Text.ToString();
            string lastName = lastNameTxt.Text.ToString();
            string email = emailTxt.Text.ToString();
            string password = passwordTxt.Text.ToString();
            DateTime lastLogin = DateTime.Now;
            bool userCreated= userAccountTable.createUserAccount(email, password, firstName, lastName, lastLogin);
            if (userCreated)
            {
                Response.Redirect("homePage.aspx");
            }
            else
            {
                //email already taken
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("homePage.aspx");
        }
    }
}