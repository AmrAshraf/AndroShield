using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.SF.Models;
using Facebook.SF.Services;
using AndroApp;
namespace AndroShield.Web_Forms
{
    public partial class facebookRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         //   if (!IsPostBack)
            {
                string code = Request.QueryString["code"];

                System.Threading.Tasks.Task<User> task = Facebook.SF.Services.Login.GetAccessTokenAsync("2277532892260615", "b38fad8cf5ef21a58c2c8a016a4a247e", "https://localhost:44302/FB/facebookRedirect.aspx/", code);
                task.Wait();
                User facebookUser = task.Result;
                userAccountTable currentUser = userAccountTable.findUserByEmail(facebookUser.email);
                if (currentUser == null)
                    currentUser = userAccountTable.findUserByFBID(long.Parse(facebookUser.id));
                if (currentUser == null)
                {
                    bool check = userAccountTable.createUserAccount(facebookUser.email, null, facebookUser.first_name, facebookUser.last_name, DateTime.Now, long.Parse(facebookUser.id));
                    if (check)
                        currentUser = userAccountTable.findUserByFBID(long.Parse(facebookUser.id));
                    else
                        currentUser = null;

                }


                if (currentUser != null)
                {
                    Session["userAccount"] = currentUser;
                    Session["password"] = currentUser.password;
                    Session["username"] = currentUser.email;
                    Session["thirdPartyLogin"] = true;
                    Response.Redirect("/Web Forms/userHomePage.aspx");
                }
               else
                {
                    Response.Redirect("incorrectCredentialsPage.aspx");
                }
            }
         /*   else
            {
                int x;
                x = 5; //for testing
            }*/
        }
    }
}