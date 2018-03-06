using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroShield.Web_Forms
{
    public partial class apkUploadPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userEmail.Text = Session["username"].ToString();
        }
        protected void signupNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfilePage.aspx");
        }
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["userAccount"] = "";
            Response.Redirect("homePage.aspx");
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Boolean fileOK = false;
                if (apkUpload.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(apkUpload.FileName).ToLower();
                    String[] allowedExtensions =
                        {".apk"};
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        apkUpload.PostedFile.SaveAs("C:\\GPTempDir\\"
                            + apkUpload.FileName);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    uploadBtn.Text = "Cannot accept files of this type.";
                }
            }
        }
    }
    
}