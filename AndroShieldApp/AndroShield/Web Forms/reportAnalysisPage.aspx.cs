using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Types;
using APKInfoExtraction;
using TaintAnalysis;
using System.Threading;
namespace AndroShield.Web_Forms
{
    public partial class reportAnalysisPage : System.Web.UI.Page
    {
        string apkPath = "";
        string apkName = "";
        APKInfoExtractor apkInfoExtraction;
        TaintAnalyser taintAnalysis;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            userEmail.Text = Session["username"].ToString();
            if(Session["currentReportName"]!=null && Session["currentReportName"].ToString() !="")
            {
                apkInfoExtraction = (APKInfoExtractor)Session["apkInfo"];
                taintAnalysis = (TaintAnalyser)Session["taint"];

                apkNameValue.Text = Session["currentReportName"].ToString();
                apkVersionValue.Text = apkInfoExtraction.versionName.ToString();
                minSdkValue.Text = apkInfoExtraction.minSDKVersion.ToString();
                targetSdkValue.Text = apkInfoExtraction.targetSDKVersion.ToString();
                if (apkInfoExtraction.testFlag)
                    testOnlyValue.Text = "True";
                else
                    testOnlyValue.Text = "False";
                packageNameValue.Text = apkInfoExtraction.packageName;
                versionNoValue.Text = apkInfoExtraction.versionCode.ToString();
                if (apkInfoExtraction.debuggableFlag)
                    debugValue.Text = "True";
                else
                    debugValue.Text = "False";
                if (apkInfoExtraction.backupFlag)
                    backupValue.Text = "True";
                else
                    backupValue.Text = "False";

                supportedArchiValue.Text = "";
                if (apkInfoExtraction.supportedArchitectures.arm64_v8a)
                    supportedArchiValue.Text += "arm64_v8a";
                if (apkInfoExtraction.supportedArchitectures.armeabi)
                    supportedArchiValue.Text += " armeabi";
                if (apkInfoExtraction.supportedArchitectures.armeabi_v7a)
                    supportedArchiValue.Text += " armeabi_v7a";
                if (apkInfoExtraction.supportedArchitectures.mips)
                    supportedArchiValue.Text += " mips";
                if (apkInfoExtraction.supportedArchitectures.mips64)
                    supportedArchiValue.Text += " mips64";
                if (apkInfoExtraction.supportedArchitectures.x86)
                    supportedArchiValue.Text += " x86";
                if (apkInfoExtraction.supportedArchitectures.x86_64)
                    supportedArchiValue.Text += " x86_64";
                if (apkInfoExtraction.supportedArchitectures.all)
                    supportedArchiValue.Text += " All";

            }
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
        protected void newAnalysisBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("apkUploadPage.aspx");
        }

        protected void allReportsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("user'sReportsPage.aspx");
        }
    }
}