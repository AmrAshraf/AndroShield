using AndroApp;
using Facebook.SF.Models;
using System;
using System.Linq;

namespace AndroShield.Web_Forms
{
    public partial class facebookRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            {
                string code = Request.QueryString["code"];
                if (code != null&& !IsPostBack)
                {

                        System.Threading.Tasks.Task<User> task = Facebook.SF.Services.Login.GetAccessTokenAsync("2277532892260615", "b38fad8cf5ef21a58c2c8a016a4a247e", "https://localhost:44302/FB/facebookRedirect.aspx/", code);
                        task.Wait();
                        User facebookUser = task.Result;
                      userAccountTable currentUser = userAccountTable.findUserByEmail(facebookUser.email);
                      if (currentUser == null)
                          currentUser = userAccountTable.findUserByFBID(long.Parse(facebookUser.id));
                    
                      if (currentUser == null)
                      {
                         Random random = new Random();
                         const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                         string pass= new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        
        
                         bool check = userAccountTable.createUserAccount(facebookUser.email, pass, facebookUser.first_name, facebookUser.last_name, DateTime.Now, long.Parse(facebookUser.id));
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
                        throw new Exception("DB+Facebook error");
                      }

                
               
                }
            }

        }
    
     
    }
}