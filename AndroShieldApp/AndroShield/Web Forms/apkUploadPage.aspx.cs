using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Types;
using APKInfoExtraction;
using TaintAnalysis;


namespace AndroApp.Web_Forms
{
    public partial class apkUploadPage : System.Web.UI.Page
    {
        string apkName;
        string uploadedFileName="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userEmail.Text = Session["username"].ToString();
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
                        analyzeBtn.Enabled = true;
                        uploadedFileName = apkUpload.FileName;
                        Session["currentReportName"] = uploadedFileName;
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

        protected void analyzeBtn_Click(object sender, EventArgs e)
        {
            apkName = Session["currentReportName"].ToString();
            string apkPath = "C:\\GPTempDir\\" + apkName;

            analyzeApk(apkPath);

            Response.Redirect("reportAnalysisPage.aspx");
        }
        void analyzeApk(string path)
        {
            string currentUser = (string)Session["username"];
            userAccountTable user = userAccountTable.findUserByEmail(currentUser);
            APKInfoExtractor apkInfoExtraction = new APKInfoExtractor(path);
            apkInfoExtraction.startExtraction();
            TaintAnalyser taintAnalysis = new TaintAnalyser(apkInfoExtraction.realApkPath);
            //TODO: apkRiskLevel determination
            apkInfoTable currentApk = apkInfoTable.insertAPKInfo(0, apkName,  apkInfoExtraction.minSDKVersion, apkInfoExtraction.targetSDKVersion, apkInfoExtraction.packageName, apkInfoExtraction.versionCode, apkInfoExtraction.versionName, apkInfoExtraction.testFlag, apkInfoExtraction.debuggableFlag, apkInfoExtraction.backupFlag, apkInfoExtraction.supportedArchitectures.all, apkInfoExtraction.supportedArchitectures.armeabi, apkInfoExtraction.supportedArchitectures.armeabi_v7a, apkInfoExtraction.supportedArchitectures.arm64_v8a, apkInfoExtraction.supportedArchitectures.x86, apkInfoExtraction.supportedArchitectures.x86_64, apkInfoExtraction.supportedArchitectures.mips, apkInfoExtraction.supportedArchitectures.mips64);
            Session["apk"] = currentApk;
            reportTable apkReport = reportTable.addNewReport(DateTime.Now.Date, true, false, currentApk.apkInfoID, user.ID);

            List<Vulnerability> apkVulnerabilities= new List<Vulnerability>();
            apkVulnerabilities.AddRange(apkInfoExtraction.vulnerabilities);
            apkVulnerabilities.AddRange(taintAnalysis.vulnerabilities);

            vulnerabilityTable dbVulnerability = new vulnerabilityTable();
            for(int i=0; i<apkVulnerabilities.Count; i++)
            {
                dbVulnerability = vulnerabilityTable.addOrFindVulnerability(apkVulnerabilities[i].severity, apkVulnerabilities[i].category, apkVulnerabilities[i].type);
                apkReport.createRelationBetweenReportAndVulnerability(apkReport.reportId, dbVulnerability.vulnID, apkVulnerabilities[i].extraInfo);
            }

            string[] permissions = apkInfoExtraction.permissions;
            
            for(int i=0; i<permissions.Length; i++)
            {
                permissionTable.addNewPermission(permissions[i]);
                currentApk.createRelationBetweenAPKInfoAndPermission(currentApk.apkInfoID, permissions[i]);
            }
            string[] launchableActivities = apkInfoExtraction.launchableActivities;
            for (int i=0; i<launchableActivities.Length; i++)
            {
                launchableActivityTable.addNewActivity(launchableActivities[i], currentApk.apkInfoID);
            }

            Session["reportID"] = apkReport.reportId;
            //Session["apkInfo"] = apkInfoExtraction;
            //Session["taint"] = taintAnalysis;
        }

    }

}