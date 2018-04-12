using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroApp.Web_Forms
{
    public partial class userProfilePage : System.Web.UI.Page
    {
        userAccountTable currentUser;
        string oldPassword;
        protected void Page_Load(object sender, EventArgs e)
        {
                currentUser = userAccountTable.findUserByEmail(Session["username"].ToString());
                userEmail.Text = Session["username"].ToString();
                oldPassword = currentUser.password;
            if(!IsPostBack)
            {

                firstNameTxt.Text = currentUser.firstName;
                lastNameTxt.Text = currentUser.lastName;

            }

            
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["userAccount"] = "";
            Response.Redirect("homePage.aspx");
        }

        protected void signupNav2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfilePage.aspx");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string fname = currentUser.firstName;
            string lname = currentUser.lastName;
            string newpass = oldPassword;


            if (passwordTxt.Text == "")
            {
                newpass = oldPassword;
            }
            else if (oldPassword!=passwordTxt.Text)
            {
                incorrectPasswordMsg.Visible = true;
            }
            else
            {
                newpass = newPassword.Text;
            }
            if(firstNameTxt.Text!=currentUser.firstName && firstNameTxt.Text!="")
            {
                fname = firstNameTxt.Text;
            }
            if (lastNameTxt.Text != currentUser.lastName && lastNameTxt.Text != "")
            {
                lname = lastNameTxt.Text;
            }
            currentUser.updateUser(DateTime.Now, newpass, Session["username"].ToString(), fname, lname);
        }

        protected void resetBtn_Click(object sender, EventArgs e)
        {
            firstNameTxt.Text = currentUser.firstName;
            lastNameTxt.Text = currentUser.lastName;
        }
    }
}