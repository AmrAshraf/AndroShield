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
        List<string> permissions;
        List<List<string>> vulnerabilities;


        protected void Page_Load(object sender, EventArgs e)
        {
            reportApk = new AndroApp.apkInfoTable();
            permissions= new List<string>();
            vulnerabilities= new List<List<string>>();

            userEmail.Text = Session["username"].ToString();
            if (!IsPostBack)
            {
                if((Session["reportID"]!=null || Session["reportID"].ToString()!=""))// && (Session["apk"]!=null))
                {
                    reportTable analysisReport = reportTable.findReportByID(int.Parse(Session["reportID"].ToString()), ref permissions, ref reportApk, ref vulnerabilities);
                    int x;
                    x = 6;
                }
                if (Session["currentReportName"] != null && Session["currentReportName"].ToString() != "")
                {
                    //apkInfoExtraction = (APKInfoExtractor)Session["apkInfo"];
                    //taintAnalysis = (TaintAnalyser)Session["taint"];

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

                    TableCell cell1 = new TableCell();
                    for (int i=0; i<permissions.Count; i++)
                    {
                        TableRow row = new TableRow();
                        cell1.Text = permissions[i];
                        row.Cells.Add(cell1);
                        permissionsTable.Rows.Add(row);
                    }
                    TableCell severity = new TableCell();
                    TableCell category = new TableCell();
                    TableCell type = new TableCell();
                    TableCell info = new TableCell();
                    for (int i = 0; i < vulnerabilities.Count; i++)
                    {
                        TableRow row = new TableRow();
                        severity = new TableCell();
                        category = new TableCell();
                        type = new TableCell();
                        info = new TableCell();

                        float severityValue = (float)Math.Round(double.Parse(vulnerabilities[i][0]), 2);
                        severity.Text = severityValue.ToString();
                        category.Text = vulnerabilities[i][1];
                        type.Text = vulnerabilities[i][2];
                        info.Text = vulnerabilities[i][3];

                        row.Cells.Add(severity);
                        row.Cells.Add(category);
                        row.Cells.Add(type);
                        row.Cells.Add(info);

                        vulnerabilityReportTable.Rows.Add(row);
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