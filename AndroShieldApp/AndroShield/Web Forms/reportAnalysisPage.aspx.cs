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
namespace AndroApp.Web_Forms
{
    public partial class reportAnalysisPage : System.Web.UI.Page
    {
        APKInfoExtractor apkInfoExtraction;
        TaintAnalyser taintAnalysis;

        apkInfoTable reportApk;
        List<permissionTable> permissions;
        List<vulnerabilityTable> vulnerabilities;


        protected void Page_Load(object sender, EventArgs e)
        {
            reportApk = new AndroApp.apkInfoTable();
            permissions= new List<permissionTable>();
            vulnerabilities= new List<vulnerabilityTable>();

            if (!IsPostBack)
            {
                if((Session["reportID"]!=null || Session["reportID"].ToString()!="") && (Session["apk"]!=null))
                {
                    reportTable analysisReport = reportTable.findReportByID(int.Parse(Session["reportID"].ToString()), permissions, reportApk, vulnerabilities);
                }
            }

                if (!IsPostBack)
            {
                userEmail.Text = Session["username"].ToString();
                if (Session["currentReportName"] != null && Session["currentReportName"].ToString() != "")
                {
                    apkInfoExtraction = (APKInfoExtractor)Session["apkInfo"];
                    taintAnalysis = (TaintAnalyser)Session["taint"];

                    apkNameValue.Text = Session["currentReportName"].ToString();
                    apkVersionValue.Text = reportApk.versionName;
                    minSdkValue.Text = reportApk.minSDK;
                    targetSdkValue.Text = reportApk.targetSDK;
                    if (reportApk.testOnly)
                        testOnlyValue.Text = "True";
                    else
                        testOnlyValue.Text = "False";
                    packageNameValue.Text = reportApk.packageName;
                    versionNoValue.Text = reportApk.versionCode;
                    versionNameValue.Text = reportApk.versionName;
                    if (reportApk.debuggable)
                        debugValue.Text = "True";
                    else
                        debugValue.Text = "False";
                    if (reportApk.backup)
                        backupValue.Text = "True";
                    else
                        backupValue.Text = "False";

                    supportedArchiValue.Text = "";
                    if (reportApk.all)
                        supportedArchiValue.Text += "All";
                    else
                    {
                        if (reportApk.armeabi)
                            supportedArchiValue.Text += "armeabi";
                        if (reportApk.armeabi_v7a)
                            supportedArchiValue.Text += ", armeabi_v7a";
                        if (reportApk.arm64_v8a)
                            supportedArchiValue.Text += ", arm64_v8a";
                        if (reportApk.x86)
                            supportedArchiValue.Text += ", x86";
                        if (reportApk.x86_64)
                            supportedArchiValue.Text += ", x86_64";
                        if (reportApk.mips)
                            supportedArchiValue.Text += ", mips";
                        if (reportApk.mips64)
                            supportedArchiValue.Text += ", mips64";
                    }

                }
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