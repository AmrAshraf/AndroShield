using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroApp
{

    public class databaseLayer
    {
       static public SqlConnection myConnection = new SqlConnection("Data Source=EREN\\MENNA;Initial Catalog=GP;Integrated Security=True");
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
                    "(apkID int CONSTRAINT PkeyIDApkInfo PRIMARY KEY IDENTITY(1,1)," +
                    "apkName varchar(MAX) , minSDK varchar(MAX), targetSdk varchar(MAX), packageName varchar(MAX), versionCode varchar(MAX)," +
                    "versionName varchar(MAX), apkRiskLevel float, testOnlyFlag bit, debuggableFlag bit, backupFlag bit," +
                    " allFlag bit, armeabiFlag bit, armeabi_v7aFlag bit, arm64_V8aFlag bit, X86Flag bit, X86_64Flag bit, mipsFlag bit, mips64Flag bit)";
                SqlCommand create = new SqlCommand(createApkInfoTable, myConnection);
                create.ExecuteNonQuery();
            }
            myConnection.Close();
        } //done testing
        private void createLaunchableActivityTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[launchableActivity]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE launchableActivity " +
                  "(launchableActivityID int CONSTRAINT PkeyLaunchedActivity PRIMARY KEY IDENTITY(1,1)," +
                 "name varchar(MAX), apkInfoID int)";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
                SqlCommand addRelation = new SqlCommand("ALTER TABLE launchableActivity ADD CONSTRAINT FK_launchableActivity_APKINFO FOREIGN KEY (apkInfoID) REFERENCES ApkInfo(apkID) On delete cascade On update cascade", myConnection);
                addRelation.ExecuteNonQuery();
            }
            myConnection.Close();
        } //done testing
        private void createUserAccountTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[userAccount]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE userAccount " +
                  "(userID int CONSTRAINT PkeyuserAccount PRIMARY KEY IDENTITY(1,1), lastLoginDate date, password varchar(MAX), email varchar(MAX) NOT NULL," +
                 "firstName varchar(MAX), lastName varchar(MAX), facebookUserID BIGINT )";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
            }
            myConnection.Close();
        } //done testing
        private void createVulnerabilityTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[vulnerability]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE vulnerability " +
                  "(vulnerabilityID int CONSTRAINT Pkeyvulnerability PRIMARY KEY IDENTITY(1,1), category varchar(MAX), type varchar(MAX)," +
                 "severity float )";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
            }
            myConnection.Close();
        } //done testing
        private void createReportTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[report]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE report " +
                  "(reportID int CONSTRAINT PkeyReport PRIMARY KEY IDENTITY(1,1), reportDate date, staticallyAnalyzed bit," +
                 "dynamicallyAnalyzed bit, apkInfoID int, userAccountID int )";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
                SqlCommand addRelation = new SqlCommand("ALTER TABLE report ADD CONSTRAINT FK_report_apkInfo FOREIGN KEY (apkInfoID) REFERENCES ApkInfo(apkID) On delete cascade On update cascade", myConnection);
                SqlCommand addNewRelation = new SqlCommand("ALTER TABLE report ADD CONSTRAINT FK_report_userAccount FOREIGN KEY (userAccountID) REFERENCES userAccount(userID) On delete cascade On update cascade", myConnection);
                addRelation.ExecuteNonQuery();
                addNewRelation.ExecuteNonQuery();
            }
            myConnection.Close();
        } //done testing
        private void createPermissionTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[permission]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE permission" +
                  "(permissionID int CONSTRAINT Pkeypermission PRIMARY KEY IDENTITY(1,1) ," +
                 "name varchar(MAX))";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
            }
            myConnection.Close();
        } //done testing
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
                SqlCommand addRelation = new SqlCommand("ALTER TABLE apkInfo_Permission ADD CONSTRAINT FK_apkInfo_PT FOREIGN KEY (apkInfoID) REFERENCES ApkInfo(apkID) On delete cascade On update cascade", myConnection);
                SqlCommand addNewRelation = new SqlCommand("ALTER TABLE apkInfo_Permission ADD CONSTRAINT FK_apkInfo_Permission FOREIGN KEY (permissionID) REFERENCES permission(permissionID) On delete cascade On update cascade", myConnection);
                addRelation.ExecuteNonQuery();
                addNewRelation.ExecuteNonQuery();
            }
            myConnection.Close();
        } //done testing
        private void createReport_VulnerabilityTable()
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[report_Vulnerability]')", myConnection);
            int result = (int)myCommand.ExecuteScalar();
            if (result == 0)
            {
                string createTable = "CREATE TABLE report_Vulnerability " +
                  "(reportID int, " +
                 "vulnerabilityID int, extraInfo varchar(MAX) )";
                SqlCommand create = new SqlCommand(createTable, myConnection);
                create.ExecuteNonQuery();
                SqlCommand addRelation = new SqlCommand("ALTER TABLE report_Vulnerability ADD CONSTRAINT FK_reportVuln FOREIGN KEY (reportID) REFERENCES report(reportID) On delete cascade On update cascade", myConnection);
                SqlCommand addNewRelation = new SqlCommand("ALTER TABLE report_Vulnerability ADD CONSTRAINT FK_reportVulnerability FOREIGN KEY (vulnerabilityID) REFERENCES vulnerability(vulnerabilityID) On delete cascade On update cascade", myConnection);
                addRelation.ExecuteNonQuery();
                addNewRelation.ExecuteNonQuery();
            }
            myConnection.Close();
        } //done testing
    }
}