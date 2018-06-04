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
        protected void Page_Load(object sender, EventArgs e)
        {
            userEmail.Text = Session["username"].ToString();
            if (!IsPostBack)
            {
                if((Session["reportID"]!=null || Session["reportID"].ToString()!=""))
                {
                    Session["analysisReport"] = reportTable.findReportByID(int.Parse(Session["reportID"].ToString()));

                    Session["AnalysisReportApk"] = ((reportTable)Session["analysisReport"]).getApkOfThisReport();
                    Session["AnalysisReportPermissions"] = ((reportTable)Session["analysisReport"]).getPermissionsofThisReport();
                    Session["AnalysisReportVulnerabilities"] = ((reportTable)Session["analysisReport"]).getVulnerabilitiesOfThisReport();

                    Session.Contents.Remove("analysisReport");
                }
                if (Session["currentReportName"] != null && Session["currentReportName"].ToString() != "")
                {
                    apkNameValue.Text = Session["currentReportName"].ToString();
                    Session.Contents.Remove("currentReportName");

                    apkVersionValue.Text = ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).versionName;
                    minSdkValue.Text = ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).minSDK;
                    targetSdkValue.Text = ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).targetSDK;
                    if (((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).testOnly)
                        testOnlyValue.Text = "True";
                    else
                        testOnlyValue.Text = "False";
                    packageNameValue.Text = ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).packageName;
                    versionNoValue.Text = ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).versionCode;
                    versionNameValue.Text = ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).versionName;
                    if (((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).debuggable)
                        debugValue.Text = "True";
                    else
                        debugValue.Text = "False";
                    if (((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).backup)
                        backupValue.Text = "True";
                    else
                        backupValue.Text = "False";

                    supportedArchiValue.Text = "";
                    if (((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).all)
                        supportedArchiValue.Text += "All";
                    else
                    {
                        Boolean firstArchi = true;
                        if (firstArchi && ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).armeabi)
                        {
                            supportedArchiValue.Text += "armeabi";
                            firstArchi = false;
                        }
                        else
                            supportedArchiValue.Text += ", armeabi";

                        if (firstArchi && ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).armeabi_v7a)
                        {
                            supportedArchiValue.Text += "armeabi_v7a";
                            firstArchi = false;
                        }
                        else
                            supportedArchiValue.Text += ", armeabi_v7a";
                        if (firstArchi && ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).arm64_v8a)
                        {
                            supportedArchiValue.Text += "arm64_v8a";
                            firstArchi = false;
                        }
                        else
                            supportedArchiValue.Text += ", arm64_v8a";
                        if (firstArchi && ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).x86)
                        {
                            supportedArchiValue.Text += "x86";
                            firstArchi = false;
                        }
                        else
                            supportedArchiValue.Text += ", x86";
                        if (firstArchi && ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).x86_64)
                        {
                            supportedArchiValue.Text += "x86_64";
                            firstArchi = false;
                        }
                        else
                            supportedArchiValue.Text += ", x86_64";
                        if (firstArchi && ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).mips)
                        {
                            supportedArchiValue.Text += "mips";
                            firstArchi = false;
                        }
                        else
                            supportedArchiValue.Text += ", mips";
                        if (firstArchi && ((AndroApp.apkInfoTable)Session["AnalysisReportApk"]).mips64)
                        {
                            supportedArchiValue.Text += "mips64";
                            firstArchi = false;
                        }
                        else
                            supportedArchiValue.Text += ", mips64";


                        Session.Contents.Remove("AnalysisReportApk");
                    }

                    TableCell cell1 = new TableCell();
                    for (int i=0; i<((List<string>)Session["AnalysisReportPermissions"]).Count; i++)
                    {
                        TableRow row = new TableRow();
                        cell1.Text = ((List<string>)Session["AnalysisReportPermissions"])[i];
                        row.Cells.Add(cell1);
                        permissionsTable.Rows.Add(row);
                    }
                    Session.Contents.Remove("AnalysisReportPermissions");

                    TableCell severity = new TableCell();
                    TableCell category = new TableCell();
                    TableCell type = new TableCell();
                    TableCell info = new TableCell();

                    //Case 1: Apk with no vulnerabilities
                    if(((List<List<string>>)Session["AnalysisReportVulnerabilities"]).Count==0)
                    {
                        cleanApkDiv.Visible = true;
                        vulnerabilityReportTable.Visible = false;
                    }
                    //Other cases:
                    else
                    {
                        cleanApkDiv.Visible = false;
                        vulnerabilityReportTable.Visible = true;

                        for (int i = 0; i < ((List<List<string>>)Session["AnalysisReportVulnerabilities"]).Count; i++)
                        {
                            TableRow row = new TableRow();
                            severity = new TableCell();
                            category = new TableCell();
                            type = new TableCell();
                            info = new TableCell();

                            Session["severityValue"] = (float)Math.Round(double.Parse(((List<List<string>>)Session["AnalysisReportVulnerabilities"])[i][0]), 2);
                            severity.Text = Session["severityValue"].ToString();
                            Session.Contents.Remove("severityValue");
                            category.Text = ((List<List<string>>)Session["AnalysisReportVulnerabilities"])[i][1];
                            type.Text = ((List<List<string>>)Session["AnalysisReportVulnerabilities"])[i][2];
                            info.Text = ((List<List<string>>)Session["AnalysisReportVulnerabilities"])[i][3];

                            row.Cells.Add(severity);
                            row.Cells.Add(category);
                            row.Cells.Add(type);
                            row.Cells.Add(info);

                            vulnerabilityReportTable.Rows.Add(row);
                        }
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
            Session.Abandon();
            Response.Redirect("homePage.aspx");
        }
        protected void newAnalysisBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("apkUploadPage.aspx",false);
        }

        protected void allReportsBtn_Click(object sender, EventArgs e)
        {
            Session["userReports"] = userAccountTable.getReportsOfThisUser(Session["username"].ToString());
            Response.Redirect("user'sReportsPage.aspx",false);
        }
    }
}