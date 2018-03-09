using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AndroApp
{
    public class reportTable
    {
        public int apkInfoID, userAccountID, reportId;
        private DateTime reportDate; 
        bool staticallyAnalyzed, dynamicallyAnalyzed;
        public reportTable()
        {
        }
        public reportTable (int ID,  int userAccountID, DateTime reportDate, bool staticallyAnalyzed, bool dynamicallyAnalyzed, int apkInfoID)
        {
            this.reportId = ID;
            this.userAccountID = userAccountID;
            this.staticallyAnalyzed = staticallyAnalyzed;
            this.dynamicallyAnalyzed = dynamicallyAnalyzed;
            this.userAccountID = userAccountID;
            this.apkInfoID = apkInfoID;
            this.reportDate = reportDate;
            
        }
        static public reportTable addNewReport ( DateTime reportDate, bool staticallyAnalyzed, bool dynamicallyAnalyzed, int apkInfoID, int userID)
        {
            databaseLayer.myConnection.Open();
          /*  SqlCommand checkExistenceOfReport = new SqlCommand("select reportID from report where reportDate=@y and apkInfoID=@x and userAccountID=@z", databaseLayer.myConnection);
            SqlParameter Paramater = new SqlParameter("@y", reportDate);
            SqlParameter secondParamater = new SqlParameter("@x", apkInfoID);
            SqlParameter thirdParamater = new SqlParameter("@z", userID);
            checkExistenceOfReport.Parameters.Add(Paramater);
            checkExistenceOfReport.Parameters.Add(secondParamater);
            checkExistenceOfReport.Parameters.Add(thirdParamater);
            checkExistenceOfReport.ExecuteNonQuery();
            SqlDataReader reader = checkExistenceOfReport.ExecuteReader();
            if (reader.Read())
            {
                reader.Dispose();
                databaseLayer.myConnection.Close();
                return null;
            }
            */
            try
            {
              //  reader.Dispose();
                SqlCommand myCommand = new SqlCommand("insert into report (reportDate,staticallyAnalyzed,dynamicallyAnalyzed,apkInfoID,userAccountID) OUTPUT INSERTED.reportID values (@a,@b,@c,@d,@e)", databaseLayer.myConnection);
                SqlParameter forthParamater = new SqlParameter("@a", reportDate);
                SqlParameter fifthParamater = new SqlParameter("@b", staticallyAnalyzed);
                SqlParameter sixthParamater = new SqlParameter("@c", dynamicallyAnalyzed);
                SqlParameter seventhParamater = new SqlParameter("@d", apkInfoID);
                SqlParameter eighthParamater = new SqlParameter("@e", userID);

                myCommand.Parameters.Add(forthParamater);
                myCommand.Parameters.Add(fifthParamater);
                myCommand.Parameters.Add(sixthParamater);
                myCommand.Parameters.Add(seventhParamater);
                myCommand.Parameters.Add(eighthParamater);

               Int32 id = (Int32) myCommand.ExecuteScalar();
                reportTable report = new reportTable(id, userID, reportDate, staticallyAnalyzed, dynamicallyAnalyzed,apkInfoID);
                databaseLayer.myConnection.Close();
                return report;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                databaseLayer.myConnection.Close();
                return null;
            }
        }
        static public reportTable findReportByID (int reportID,  List<permissionTable> listOfPermissions,  apkInfoTable apkInfoOfThisReport,  List<vulnerabilityTable> vulnerabilityListOfThisReport)
        {
            //try
            //{
                databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Select * from  report where reportID=@y", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@y", reportID);
                myCommand.Parameters.Add(secondParamater);
                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.Read())
                { 
                    Int32 Id = (Int32)reader[0];
                    DateTime reportDate = (DateTime)reader[1];
                    bool staticallyAnalyzed = (bool)reader[2];
                    bool dynamicallyAnalyzed = (bool)reader[3];
                    Int32 apkInfoID = (Int32)reader[4];
                    Int32 userAccountID = (Int32)reader[5];
                    reportTable rep = new reportTable( Id,  userAccountID,  reportDate,  staticallyAnalyzed,  dynamicallyAnalyzed,apkInfoID);
                    listOfPermissions = rep.getPermissionsofThisReport(reportID);
                    apkInfoOfThisReport  = rep.getApkOfThisReport(reportID);
                    vulnerabilityListOfThisReport = rep.getVulnerabilitiesOfThisReport(reportID);
                    reader.Dispose();
                    databaseLayer.myConnection.Close();
                    return rep;
                }
                else
                {
                    databaseLayer.myConnection.Close();
                    return null;
                }
            //}
            //catch (System.InvalidOperationException)
            //{
            //    databaseLayer.myConnection.Close();
            //    return null;
            //}

        }
        public bool createRelationBetweenReportAndVulnerability (int reportID, int vulID, string extraInfo)
        {
            databaseLayer.myConnection.Open();
            //SqlCommand checkExistenceOfRelation = new SqlCommand("select reportID from report_Vulnerability where extraInfo=@y", databaseLayer.myConnection);
            //SqlParameter Paramater = new SqlParameter("@y", extraInfo);
            //checkExistenceOfRelation.Parameters.Add(Paramater);
            //checkExistenceOfRelation.ExecuteNonQuery();
            //SqlDataReader reader = checkExistenceOfRelation.ExecuteReader();
            //if (reader.Read())
            //{
            //    reader.Dispose();
            //    databaseLayer.myConnection.Close();
            //    return false;
            //}

            //try
            //{
            //    reader.Dispose();
                SqlCommand myCommand = new SqlCommand("insert into report_Vulnerability (reportID,vulnerabilityID,extraInfo) values (@a,@b,@c)", databaseLayer.myConnection);
                SqlParameter forthParamater = new SqlParameter("@a", reportId);
                SqlParameter fifthParamater = new SqlParameter("@b", vulID);
            extraInfo = "test";
                SqlParameter sixthParamater = new SqlParameter("@c", extraInfo);
                myCommand.Parameters.Add(forthParamater);
                myCommand.Parameters.Add(fifthParamater);
                myCommand.Parameters.Add(sixthParamater);
                myCommand.ExecuteNonQuery();
                databaseLayer.myConnection.Close();
                return true;
            //}
            //catch (System.Data.SqlClient.SqlException)
            //{
            //    databaseLayer.myConnection.Close();
            //    return false;
            //}
            //return false;
        }
        public apkInfoTable getApkOfThisReport (int reportID)
        {
            //try
            //{
                apkInfoTable apkk;
                if (databaseLayer.myConnection.State == ConnectionState.Closed)
                    databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Select apkInfoID from  report where reportID=@y", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@y", reportID);
                myCommand.Parameters.Add(secondParamater);
                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.Read())
                {
                    Int32 apkID = (Int32)reader[0];
                    SqlCommand apk = new SqlCommand("Select * from ApkInfo where apkID=@id", databaseLayer.myConnection);
                    SqlParameter id = new SqlParameter("@id", apkID);
                    apk.Parameters.Add(id);
                    SqlDataReader apkInfo = apk.ExecuteReader();
                    if(apkInfo.Read())
                    {
                        String apkName = (String)apkInfo[1];
                        String minSDK = (String)apkInfo[2];
                        String targetSdk = (String)apkInfo[3];
                        String packageName = (String)apkInfo[4];
                        String versionCode = (String)apkInfo[5];
                        String versionName = (String)apkInfo[6];
                        float apkRiskLevel = float.Parse(apkInfo[7].ToString());
                        bool testOnlyFlag = bool.Parse(apkInfo[8].ToString());
                        bool debuggableFlag = bool.Parse(apkInfo[9].ToString());
                        bool backupFlag = bool.Parse(apkInfo[10].ToString());
                        bool allFlag = bool.Parse(apkInfo[11].ToString());
                        bool armeabiFlag = bool.Parse(apkInfo[12].ToString());
                        bool armeabi_v7aFlag = bool.Parse(apkInfo[13].ToString());
                        bool arm64_V8aFlag = bool.Parse(apkInfo[14].ToString());
                        bool X86Flag = bool.Parse(apkInfo[15].ToString());
                        bool X86_64Flag = bool.Parse(apkInfo[16].ToString());
                        bool mipsFlag = bool.Parse(apkInfo[17].ToString());
                        bool mips64Flag = bool.Parse(apkInfo[18].ToString());
                        apkk = new apkInfoTable( apkInfoID,  apkRiskLevel,  apkName,  minSDK,  targetSdk,  packageName,  versionCode,  versionName,  testOnlyFlag,  debuggableFlag,  backupFlag,  allFlag,  armeabiFlag,  armeabi_v7aFlag,  arm64_V8aFlag,  X86Flag, X86_64Flag, mipsFlag, mips64Flag);
                        apkInfo.Dispose();
                    }
                    else
                    {
                        apkInfo.Dispose();
                        return null;
                    }
                    reader.Dispose();
                    return apkk;
                }
                else
                {
                    return null;
                }
            //}
            //catch (System.InvalidOperationException)
            //{
            //    return null;
            //}

        }
        public List<vulnerabilityTable> getVulnerabilitiesOfThisReport (int reportID)
        {
            try
            {
                if(databaseLayer.myConnection.State == ConnectionState.Closed)
                    databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Select VulnerabilityID from  report_Vulnerability where reportID=@y", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@y", reportID);
                myCommand.Parameters.Add(secondParamater);
                SqlDataReader reader = myCommand.ExecuteReader();
                HashSet<int> vulnIDs = new HashSet<int>();
                while (reader.Read())
                {

                    Int32 Id = (Int32)reader[0];
                    vulnIDs.Add(Id);
                }
                reader.Dispose();
                try
                {
                    int i = 0;
                    List<vulnerabilityTable> vulnObjs = new List<vulnerabilityTable>();
                    while (i<vulnIDs.Count())
                    {
                        myCommand = new SqlCommand("Select * from  vulnerability where vulnerabilityID=@y", databaseLayer.myConnection);
                        SqlParameter thirdParamater = new SqlParameter("@y", vulnIDs.ElementAt(i));
                        myCommand.Parameters.Add(thirdParamater);
                        reader = myCommand.ExecuteReader();
                        Int32 vulnerabilityID = (Int32)reader[0];
                        String category = (String)reader[1];
                        String type = (String)reader[2];
                        float severity = (float)reader[3];
                        vulnerabilityTable vul = new vulnerabilityTable( vulnerabilityID,  severity,  category,  type);
                        vulnObjs.Add(vul);
                        i++;
                    }
                    reader.Dispose();
                    //databaseLayer.myConnection.Close();
                    return vulnObjs;

                }
                catch
                {
                    //databaseLayer.myConnection.Close();
                    return null;
                }
            }
            catch (System.InvalidOperationException)
            {
                //databaseLayer.myConnection.Close();
                return null;
            }
        }
        public List<permissionTable> getPermissionsofThisReport (int reportID)
        {

                apkInfoTable apk = getApkOfThisReport(reportID);
                List<permissionTable> perms = apk.getAllPermissionThatExistInThisAPK(apk.apkInfoID);
                return perms;

        }
        public bool deleteRecord(int ID)
        {
            try
            {
                databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Delete from report where reportID=@y", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@y", ID);
                myCommand.Parameters.Add(secondParamater);
                myCommand.ExecuteNonQuery();
                databaseLayer.myConnection.Close();
                return true;
            }
            catch
            {
                databaseLayer.myConnection.Close();
                return false;
            }
        }
        public bool updateReport ( int userAccountID, DateTime reportDate, bool staticallyAnalyzed, bool dynamicallyAnalyzed,int apkID)
        {
            try
            {
                databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("update report set reportDate=@a,staticallyAnalyzed=@b,dynamicallyAnalyzed=@c,apkInfoID=@d,userAccountID=@e", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@a", reportDate);
                SqlParameter thirdParamater = new SqlParameter("@b", staticallyAnalyzed);
                SqlParameter forthParamater = new SqlParameter("@c", dynamicallyAnalyzed);
                SqlParameter fifthParamater = new SqlParameter("@d", apkID);
                SqlParameter sixthParamater = new SqlParameter("@e", userAccountID);
                myCommand.Parameters.Add(secondParamater);
                myCommand.Parameters.Add(thirdParamater);
                myCommand.Parameters.Add(forthParamater);
                myCommand.Parameters.Add(fifthParamater);
                myCommand.Parameters.Add(sixthParamater);
                myCommand.ExecuteNonQuery();
                databaseLayer.myConnection.Close();
                return true;
            }
            catch
            {
                databaseLayer.myConnection.Close();
                return false;
            }
        }
    }
}