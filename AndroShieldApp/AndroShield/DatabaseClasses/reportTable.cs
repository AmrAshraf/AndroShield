using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroShield
{
    public class reportTable
    {
        private int apkInfoID, userAccountID, reportId;
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
            
        }
        static public reportTable addNewReport ( DateTime reportDate, bool staticallyAnalyzed, bool dynamicallyAnalyzed, int apkInfoID, int userID)
        {
            databaseLayer.myConnection.Open();
            SqlCommand checkExistenceOfReport = new SqlCommand("select reportID from report where reportDate=@y and apkInfoID=@x and userAccountID=@z", databaseLayer.myConnection);
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
                databaseLayer.myConnection.Close();
                reader.Dispose();
                return null;
            }

            try
            {
                reader.Dispose();
                SqlCommand myCommand = new SqlCommand("insert into report (reportDate,staticallyAnalyzed,dynamicallyAnalyzed,apkInfoID,userAccountID) OUTPUT INSERTED.ID values (@a,@b,@c,@d,@e)", databaseLayer.myConnection);
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
            catch (System.Data.SqlClient.SqlException)
            {
                databaseLayer.myConnection.Close();
                return null;
            }
        }
        static public reportTable findReportByID (int reportID,  List<permissionTable> listOfPermissions,  apkInfoTable apkInfoOfThisReport,  List<vulnerabilityTable> vulnerabilityListOfThisReport)
        {
            try
            {
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
            }
            catch (System.InvalidOperationException)
            {
                databaseLayer.myConnection.Close();
                return null;
            }

        }
        public bool createRelationBetweenReportAndVulnerability (int reportID, int vulID, string extraInfo)
        {
            databaseLayer.myConnection.Open();
            SqlCommand checkExistenceOfRelation = new SqlCommand("select reportID from report_Vulnerability where extraInfo=@y", databaseLayer.myConnection);
            SqlParameter Paramater = new SqlParameter("@y", extraInfo);
            checkExistenceOfRelation.Parameters.Add(Paramater);
            checkExistenceOfRelation.ExecuteNonQuery();
            SqlDataReader reader = checkExistenceOfRelation.ExecuteReader();
            if (reader.Read())
            {
                databaseLayer.myConnection.Close();
                reader.Dispose();
                return false;
            }

            try
            {
                reader.Dispose();
                SqlCommand myCommand = new SqlCommand("insert into report_Vulnerability (reportID,vulnerabilityID,extraInfo) values (@a,@b,@c)", databaseLayer.myConnection);
                SqlParameter forthParamater = new SqlParameter("@a", reportId);
                SqlParameter fifthParamater = new SqlParameter("@b", vulID);
                SqlParameter sixthParamater = new SqlParameter("@c", extraInfo);
                myCommand.Parameters.Add(forthParamater);
                myCommand.Parameters.Add(fifthParamater);
                myCommand.Parameters.Add(sixthParamater);
                myCommand.ExecuteNonQuery();
                databaseLayer.myConnection.Close();
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                databaseLayer.myConnection.Close();
                return false;
            }
        }
        public apkInfoTable getApkOfThisReport (int reportID)
        {
            try
            {
                databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Select apkInfoID from  report where reportID=@y", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@y", reportID);
                myCommand.Parameters.Add(secondParamater);
                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.Read())
                {
                    Int32 apkID = (Int32)reader[0];
                    String apkName = (String)reader[0];
                    String apkVersion = (String)reader[1];
                    String minSDK = (String)reader[2];
                    String targetSdk = (String)reader[3];
                    String packageName = (String)reader[4];
                    String versionNumber = (String)reader[5];
                    String versionName = (String)reader[6];
                    float apkRiskLevel = (float)reader[7];
                    bool testOnlyFlag = (bool)reader[8];
                    bool debuggableFlag = (bool)reader[9];
                    bool backupFlag = (bool)reader[10];
                    bool allFlag = (bool)reader[11];
                    bool armeabiFlag = (bool)reader[12];
                    bool armeabi_v7aFlag = (bool)reader[13];
                    bool arm64_V8aFlag = (bool)reader[14];
                    bool X86Flag = (bool)reader[15];
                    bool X86_64Flag = (bool)reader[16];
                    bool mipsFlag = (bool)reader[17];
                    bool mips64Flag = (bool)reader[18];
                    apkInfoTable apk = new apkInfoTable( apkInfoID,  apkRiskLevel,  apkName,  apkVersion,  minSDK,  targetSdk,  packageName,  versionNumber,  versionName,  testOnlyFlag,  debuggableFlag,  backupFlag,  allFlag,  armeabiFlag,  armeabi_v7aFlag,  arm64_V8aFlag,  X86Flag, X86_64Flag, mipsFlag, mips64Flag);
                    reader.Dispose();
                    databaseLayer.myConnection.Close();
                    return apk;
                }
                else
                {
                    databaseLayer.myConnection.Close();
                    return null;
                }
            }
            catch (System.InvalidOperationException)
            {
                databaseLayer.myConnection.Close();
                return null;
            }

        }
        public List<vulnerabilityTable> getVulnerabilitiesOfThisReport (int reportID)
        {
            try
            {
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
                    databaseLayer.myConnection.Close();
                    return vulnObjs;

                }
                catch
                {
                    databaseLayer.myConnection.Close();
                    return null;
                }
            }
            catch (System.InvalidOperationException)
            {
                databaseLayer.myConnection.Close();
                return null;
            }
        }
        public List<permissionTable> getPermissionsofThisReport (int reportID)
        {
            try
            {
                apkInfoTable apk = getApkOfThisReport(reportID);
                List<permissionTable> perms = apk.getAllPermissionThatExistInThisAPK(apk.apkInfoID);
                return perms;
            }
            catch
            {
                return null;
            }
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