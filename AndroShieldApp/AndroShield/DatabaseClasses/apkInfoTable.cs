using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using AndroApp.Web_Forms;
using Types;
using TaintAnalysis;
using APKInfoExtraction;
namespace AndroApp
{
    public class apkInfoTable
    {
        public int apkInfoID;
        public float apkRiskLevel;
        public string apkName, minSDK, targetSDK, packageName, versionCode, versionName;
        public bool testOnly, debuggable, backup, all, armeabi, armeabi_v7a, arm64_v8a, x86, x86_64, mips, mips64;
        public apkInfoTable()
        {
        }
        public apkInfoTable(int apkInfoID, float apkRiskLevel, string apkName, string minSDK, string targetSDK, string packageName, string versionCode, string versionName, bool testOnly, bool debuggable, bool backup, bool all, bool armeabi, bool armeabi_v7a, bool arm64_v8a, bool x86, bool x86_64, bool mips, bool mips64)
        {
            this.apkInfoID = apkInfoID;
            this.apkRiskLevel = apkRiskLevel;
            this.apkName = apkName;
          //  this.apkVersion = apkVersion;
            this.minSDK = minSDK;
            this.targetSDK = targetSDK;
            this.packageName = packageName;
            this.versionCode = versionCode;
            this.versionName = versionName;
            this.testOnly = testOnly;
            this.debuggable = debuggable;
            this.backup = backup;
            this.all = all;
            this.armeabi = armeabi;
            this.armeabi_v7a = armeabi_v7a;
            this.arm64_v8a = arm64_v8a;
            this.x86 = x86;
            this.x86_64 = x86_64;
            this.mips = mips;
            this.mips64 = mips64;
        }
        static public apkInfoTable insertAPKInfo(float apkRiskLevel, string apkName, string minSDK, string targetSDK, string packageName, string versionCode, string versionName, bool testOnly, bool debuggable, bool backup, bool all, bool armeabi, bool armeabi_v7a, bool arm64_v8a, bool x86, bool x86_64, bool mips, bool mips64)
        {
            databaseLayer.myConnection.Open();
         /*   SqlCommand checkExistenceOfAPK = new SqlCommand("select apkID from ApkInfo where versionCode=@y and packageName=@z", databaseLayer.myConnection);
            SqlParameter Paramater = new SqlParameter("@y", versionCode); 
            SqlParameter secondParamater = new SqlParameter("@z", packageName);
            checkExistenceOfAPK.Parameters.Add(Paramater);
            checkExistenceOfAPK.Parameters.Add(secondParamater);
            checkExistenceOfAPK.ExecuteNonQuery();//TODO: change the logic of this uniqueness check because it prevent analyze the same apk from our system
            SqlDataReader reader = checkExistenceOfAPK.ExecuteReader();
            if (reader.Read())
            {
                reader.Dispose();
                databaseLayer.myConnection.Close();
                return null;
            }*/
            try
            {
              //  reader.Dispose();
                /*          SqlCommand myCommand = new SqlCommand("insert into ApkInfo (" +
                              "apkName, apkVersion , minSDK , targetSdk , packageName , versionCode ," +
                              "versionName , apkRiskLevel , testOnlyFlag , debuggableFlag , backupFlag ," +
                              " allFlag , armeabiFlag , armeabi_v7aFlag , arm64_V8aFlag , X86Flag , X86_64Flag , mipsFlag , mips64Flag ) OUTPUT INSERTED.ID values (@b,@c,@d,@e,@f,@h,@I,@J,@K,@L,@M,@N,@O,@P,@Q,@R,@S,@T)", databaseLayer.myConnection);*/
                SqlCommand myCommand = new SqlCommand("insert into ApkInfo (" +
               "apkName , minSDK , targetSdk , packageName , versionCode ," +
               "versionName , apkRiskLevel , testOnlyFlag , debuggableFlag , backupFlag ," +
               " allFlag , armeabiFlag , armeabi_v7aFlag , arm64_V8aFlag , X86Flag , X86_64Flag , mipsFlag , mips64Flag ) OUTPUT INSERTED.apkID values (@b,@d,@c,@e,@f,@h,@I,@J,@K,@L,@M,@N,@O,@P,@Q,@R,@S,@T)", databaseLayer.myConnection);
                //it is OUTPUT INSERTED.apkID  not  OUTPUT INSERTED.ID and no need for it
                SqlParameter secondParameter = new SqlParameter("@b", apkName);
                SqlParameter forthParameter = new SqlParameter("@d", minSDK);
                SqlParameter thirdParameter = new SqlParameter("@c", targetSDK);
                SqlParameter fifthParameter = new SqlParameter("@e", packageName);
                SqlParameter sixthParameter = new SqlParameter("@f", versionCode);
                SqlParameter seventhParemeter = new SqlParameter("@h", versionName);
                SqlParameter eighthParameter = new SqlParameter("@I", apkRiskLevel);
                SqlParameter ninthParameter = new SqlParameter("@J", testOnly);
                SqlParameter tenthParameter = new SqlParameter("@K", debuggable);
                SqlParameter eleventhParameter = new SqlParameter("@L", backup);
                SqlParameter twelvethParameter = new SqlParameter("@M", all);
                SqlParameter T13th = new SqlParameter("@N", armeabi);
                SqlParameter T14th = new SqlParameter("@O", armeabi_v7a);
                SqlParameter T15th = new SqlParameter("@P", arm64_v8a);
                SqlParameter T16th = new SqlParameter("@Q", x86);
                SqlParameter T17th = new SqlParameter("@R", x86_64);
                SqlParameter T18th = new SqlParameter("@S", mips);
                SqlParameter T19th = new SqlParameter("@T", mips64);
            
                myCommand.Parameters.Add(secondParameter);
                myCommand.Parameters.Add(forthParameter);
                myCommand.Parameters.Add(thirdParameter);
                myCommand.Parameters.Add(fifthParameter);
                myCommand.Parameters.Add(sixthParameter);
                myCommand.Parameters.Add(seventhParemeter);
                myCommand.Parameters.Add(eighthParameter);
                myCommand.Parameters.Add(ninthParameter);
                myCommand.Parameters.Add(tenthParameter);
                myCommand.Parameters.Add(eleventhParameter);
                myCommand.Parameters.Add(twelvethParameter);
                myCommand.Parameters.Add(T13th);
                myCommand.Parameters.Add(T14th);
                myCommand.Parameters.Add(T15th);
                myCommand.Parameters.Add(T16th);
                myCommand.Parameters.Add(T17th);
                myCommand.Parameters.Add(T18th);
                myCommand.Parameters.Add(T19th);
                Int32 Id = (Int32)myCommand.ExecuteScalar(); // works only with output clause
                apkInfoTable apkInfo = new apkInfoTable(Id, apkRiskLevel, apkName, minSDK, targetSDK, packageName, versionCode, versionName, testOnly, debuggable, backup, all, armeabi, armeabi_v7a, arm64_v8a, x86, x86_64, mips, mips64);
                databaseLayer.myConnection.Close();
                return apkInfo;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                databaseLayer.myConnection.Close();
                return null;
            }
        }
        public List<reportTable> getAllReportsThatContainThisAPK(int ID)
        {
            try
            {
                databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Select * from report where apkInfoID=@y", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@y", ID);
                myCommand.Parameters.Add(secondParamater);
                SqlDataReader reader = myCommand.ExecuteReader();
                List<reportTable> reports = new List<reportTable>();
                while (reader.Read())
                {

                    Int32 Id = (Int32)reader[0];
                    DateTime date = (DateTime)reader[1];
                    bool staticallyAnalyzed = (bool)reader[2];
                    bool dynamicallyAnalyzed = (bool)reader[3];
                    Int32 apkInfoID = (Int32)reader[4];
                    Int32 userID = (Int32)reader[5];
                    reportTable report = new reportTable(Id, userID, date, staticallyAnalyzed, dynamicallyAnalyzed,apkInfoID);
                    reports.Add(report);

                }
                reader.Dispose();
                databaseLayer.myConnection.Close();
                return reports;
            }
            catch (System.InvalidOperationException)
            {
                databaseLayer.myConnection.Close();
                return null;
            }

        }
        public bool deleteRecord(int ID)
        {
            try
            {
                databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Delete from ApkInfo where apkInfoID=@y", databaseLayer.myConnection);
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
        public List<string> getAllPermissionThatExistInThisAPK(int ID)
        {
            try
            {
                if(databaseLayer.myConnection.State == System.Data.ConnectionState.Closed)
                    databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("select permission.name from permission inner join apkInfo_Permission on permission.permissionID = apkInfo_Permission.permissionID where apkInfo_Permission.apkInfoID=@id", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@id", ID);
                myCommand.Parameters.Add(secondParamater);
                SqlDataReader reader = myCommand.ExecuteReader();
                List<string> permissions = new List<string>();
                while(reader.Read())
                {
                    permissions.Add(reader[0].ToString());
                }
                reader.Dispose();
                return permissions;
                //List<int> permissionIDs = new List<int>();
                //while (reader.Read())
                //{

                //    Int32 Id = (Int32)reader[0];
                //    permissionIDs.Add(Id);
                //}
                //reader.Dispose();
                //try
                //{
                //    int i = 0;
                //    List<permissionTable> permissionObjs = new List<permissionTable>();
                //    while (i<permissionIDs.Count())
                //    {
                //        myCommand = new SqlCommand("Select * from  permission where permissionID=@y", databaseLayer.myConnection);
                //        SqlParameter thirdParamater = new SqlParameter("@y", permissionIDs[i]);
                //        myCommand.Parameters.Add(thirdParamater);
                //        reader = myCommand.ExecuteReader();
                //        Int32 index = (Int32)reader[0];
                //        string name = (string)reader[1];
                //        permissionTable perm = new permissionTable(index, name);
                //        permissionObjs.Add(perm);
                //        i++;
                //    }
                //    reader.Dispose();
                //    databaseLayer.myConnection.Close();
                //    return permissionObjs;

                //}
                //catch
                //{
                //    databaseLayer.myConnection.Close();
                //    return null;
                //}
            }
            catch (System.InvalidOperationException)
            {
                databaseLayer.myConnection.Close();
                return null;
            }

        }
        //public List<launchableActivityTable> getAllActivitiesInThisAPK(int ID)
        //{
        //    try
        //    {
        //        databaseLayer.myConnection.Open();
        //        SqlCommand myCommand = new SqlCommand("Select * from launchableActivity where apkInfoID=@y", databaseLayer.myConnection);
        //        SqlParameter secondParamater = new SqlParameter("@y", ID);
        //        myCommand.Parameters.Add(secondParamater);
        //        SqlDataReader reader = myCommand.ExecuteReader();
        //        List<launchableActivityTable> activities = new List<launchableActivityTable>();
        //        while (reader.Read())
        //        {

        //            Int32 Id = (Int32)reader[0];
        //            string name = (string)reader[1];
        //            Int32 apkID = (Int32)reader[2];
        //            launchableActivityTable launchable = new launchableActivityTable(Id, apkID, name);
        //            activities.Add(launchable);
        //        }
        //        reader.Dispose();
        //        databaseLayer.myConnection.Close();
        //        return activities;
        //    }
        //    catch (System.InvalidOperationException)
        //    {
        //        databaseLayer.myConnection.Close();
        //        return null;
        //    }

        //}
        public bool createRelationBetweenAPKInfoAndPermission(int apkInfoID, string PermissionName)
        {
            try
            {
                databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Select permissionID from permission where name=@y", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@y", PermissionName);
                myCommand.Parameters.Add(secondParamater);
                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.Read())
                {

                    Int32 permissionId = (Int32)reader[0];
                    reader.Dispose();
                    try
                    {
                        SqlCommand checkExistenceOfRelation = new SqlCommand("select * from apkInfo_Permission where apkInfoID=@y and permissionID=@z", databaseLayer.myConnection);
                        SqlParameter Paramater = new SqlParameter("@y", apkInfoID);
                        SqlParameter thirdParamater = new SqlParameter("@z", permissionId);
                        checkExistenceOfRelation.Parameters.Add(Paramater);
                        checkExistenceOfRelation.Parameters.Add(thirdParamater);
                        checkExistenceOfRelation.ExecuteNonQuery();
                        reader = checkExistenceOfRelation.ExecuteReader();
                        if (reader.Read())
                        {
                            reader.Dispose();
                            databaseLayer.myConnection.Close();
                            return false;
                        }
                        try
                        {
                            reader.Dispose();
                            myCommand = new SqlCommand("insert into apkInfo_Permission (" +
                           "apkInfoID, permissionID)values (@b,@c)", databaseLayer.myConnection);
                            SqlParameter forthParamater = new SqlParameter("@b", apkInfoID);
                            SqlParameter fifthParamter = new SqlParameter("@c", permissionId);
                            myCommand.Parameters.Add(forthParamater);
                            myCommand.Parameters.Add(fifthParamter);
                            myCommand.ExecuteNonQuery();
                            databaseLayer.myConnection.Close();
                            return true;

                        }
                        catch(Exception ex)
                        {
                            databaseLayer.myConnection.Close();
                            return false;
                        }
                    }
                    catch (System.InvalidOperationException)
                    {
                        databaseLayer.myConnection.Close();
                        return false;
                    }

                }

                else
                {
                    databaseLayer.myConnection.Close();
                    return false;
                }
            }
            catch (System.InvalidOperationException)
            {
                databaseLayer.myConnection.Close();
                return false;
            }


        }

    }
}