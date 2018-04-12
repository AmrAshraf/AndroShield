using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroShield
{

    public class databaseLayer
    {
        SqlConnection myConnection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=AndroShield;Integrated Security=True");
        public databaseLayer()
        {
            createAPKInfoTable();
            createLaunchableActivityTable();
            createUserAccountTable();
            createVulnerabilityTable();
            createReportTable();
            createPermissionTable();
            createApkInfo_PermissionTable();
            createReport_VulnerabilityTable();
        }
        private void createAPKInfoTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[apkInfo]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createApkInfoTable = "CREATE TABLE ApkInfo" +
                    "(apkID int CONSTRAINT PkeyIDApkInfo PRIMARY KEY," +
                    "apkName varchar(50) , apkVersion varchar(50), minSDK varchar(50), targetSdk varchar(50), packageName varchar(50), versionNumber varchar(50)," +
                    "versionName varchar(50), apkRiskLevel float, testOnlyFlag bit, debuggableFlag bit, backupFlag bit," +
                    " allFlag bit, armeabiFlag bit, armeabi_v7aFlag bit, arm64_V8aFlag bit, X86Flag bit, X86_64Flag bit, mipsFlag bit, mips64Flag bit)";
                SqlCommand create = new SqlCommand(createApkInfoTable, myConnection);
                create.ExecuteNonQuery();
            }
            myConnection.Close();
        }
        private void createLaunchableActivityTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[launchableActivity]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE launchableActivity " +
                  "(launchableActivityID int CONSTRAINT PkeyLaunchedActivity PRIMARY KEY," +
                 "name varchar(50), apkInfoID int)";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
                SqlCommand addRelation = new SqlCommand("ALTER TABLE launchableActivity ADD CONSTRAINT FK_launchableActivity_APKINFO FOREIGN KEY (apkInfoID) REFERENCES ApkInfo(apkID) On delete set NULL On update cascade", myConnection);
                addRelation.ExecuteNonQuery();
            }
            myConnection.Close();
        }
        private void createUserAccountTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[userAccount]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE userAccount " +
                  "(userID int CONSTRAINT PkeyuserAccount PRIMARY KEY IDENTITY(1,1), lastLoginDate date, password varchar(50), email varchar(50) NOT NULL," +
                 "firstName varchar(50), lastName varchar(50) )";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
            }
            myConnection.Close();
        }
        private void createVulnerabilityTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[vulnerability]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE vulnerability " +
                  "(vulnerabilityID int CONSTRAINT Pkeyvulnerability PRIMARY KEY, category varchar(50), type varchar(50)," +
                 "severity float )";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
            }
            myConnection.Close();
        }
        private void createReportTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[report]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE report " +
                  "(reportID int CONSTRAINT PkeyReport PRIMARY KEY, reportDate date, staticallyAnalyzed bit," +
                 "dynamicallyAnalyzed bit, apkInfoID int, userAccountID int )";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
                SqlCommand addRelation = new SqlCommand("ALTER TABLE report ADD CONSTRAINT FK_report_apkInfo FOREIGN KEY (apkInfoID) REFERENCES ApkInfo(apkID) On delete set NULL On update cascade", myConnection);
                SqlCommand addNewRelation = new SqlCommand("ALTER TABLE report ADD CONSTRAINT FK_report_userAccount FOREIGN KEY (userAccountID) REFERENCES userAccount(userID) On delete set NULL On update cascade", myConnection);
                addRelation.ExecuteNonQuery();
                addNewRelation.ExecuteNonQuery();
            }
            myConnection.Close();
        }
        private void createPermissionTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[permission]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE permission " +
                  "(permissionID int CONSTRAINT Pkeypermission PRIMARY KEY," +
                 "name varchar(50))";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
            }
            myConnection.Close();
        }
        private void createApkInfo_PermissionTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[apkInfo_Permission]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE apkInfo_Permission " +
                  "(apkInfoID int, " +
                 "permissionID int )";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
                SqlCommand addRelation = new SqlCommand("ALTER TABLE apkInfo_Permission ADD CONSTRAINT FK_apkInfo_PT FOREIGN KEY (apkInfoID) REFERENCES ApkInfo(apkID) On delete set NULL On update cascade", myConnection);
                SqlCommand addNewRelation = new SqlCommand("ALTER TABLE apkInfo_Permission ADD CONSTRAINT FK_apkInfo_Permission FOREIGN KEY (permissionID) REFERENCES permission(permissionID) On delete set NULL On update cascade", myConnection);
                addRelation.ExecuteNonQuery();
                addNewRelation.ExecuteNonQuery();
            }
            myConnection.Close();
        }
        private void createReport_VulnerabilityTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[report_Vulnerability]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE report_Vulnerability " +
                  "(reportID int, " +
                 "vulnerabilityID int, extraInfo varchar(50) )";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
                SqlCommand addRelation = new SqlCommand("ALTER TABLE report_Vulnerability ADD CONSTRAINT FK_reportVuln FOREIGN KEY (reportID) REFERENCES report(reportID) On delete set NULL On update cascade", myConnection);
                SqlCommand addNewRelation = new SqlCommand("ALTER TABLE report_Vulnerability ADD CONSTRAINT FK_reportVulnerability FOREIGN KEY (vulnerabilityID) REFERENCES vulnerability(vulnerabilityID) On delete set NULL On update cascade", myConnection);
                addRelation.ExecuteNonQuery();
                addNewRelation.ExecuteNonQuery();
            }
            myConnection.Close();
        }
    }
}