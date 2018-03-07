using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroApp
{
    public class apkInfoTable
    {
        private int apkID;
        private float apkRiskLevel;
        private string apkName, apkVersion, minSDK, targetSDK, packageName, versionNumber, versionName;
        bool testOnly, debuggable, backup, all, armeabi, armeabi_v7a, arm64_v8a, x86, x86_64, mips, mips64;
       public apkInfoTable() { }
       public apkInfoTable(int apkID, float apkRiskLevel, string apkName, string apkVersion, string minSDK, string targetSDK, string packageName, string versionNumber, string versionName, bool testOnly, bool debuggable, bool backup, bool all, bool armeabi, bool armeabi_v7a, bool arm64_v8a, bool x86, bool x86_64, bool mips, bool mips64)
        {
            this.apkID = apkID;
            this.apkRiskLevel = apkRiskLevel;
            this.apkName = apkName;
            this.apkVersion = apkVersion;
            this.minSDK = minSDK;
            this.targetSDK = targetSDK;
            this.packageName = packageName;
            this.versionNumber = versionNumber;
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

     static  public bool insertAPK (int apkID, float apkRiskLevel, string apkName, string apkVersion, string minSDK, string targetSDK, string packageName, string versionNumber, string versionName, bool testOnly, bool debuggable, bool backup, bool all, bool armeabi, bool armeabi_v7a, bool arm64_v8a, bool x86, bool x86_64, bool mips, bool mips64)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=AndroShield;Integrated Security=True");
            myConnection.Open();
            SqlCommand checkExistenceOfUser = new SqlCommand("select apkID from ApkInfo where apkID=@y", myConnection);
            SqlParameter Paramater = new SqlParameter("@y", apkID);
            checkExistenceOfUser.Parameters.Add(Paramater);
            checkExistenceOfUser.ExecuteNonQuery();
            SqlDataReader reader = checkExistenceOfUser.ExecuteReader();
            if (reader.Read())
                return false;
            try
            {
                reader.Dispose();
                SqlCommand myCommand = new SqlCommand("insert into ApkInfo (apkID," +
                    "apkName, apkVersion , minSDK , targetSdk , packageName , versionNumber ," +
                    "versionName , apkRiskLevel , testOnlyFlag , debuggableFlag , backupFlag ," +
                    " allFlag , armeabiFlag , armeabi_v7aFlag , arm64_V8aFlag , X86Flag , X86_64Flag , mipsFlag , mips64Flag ) values (@a,@b,@c,@d,@e,@f,@h,@I,@J,@K,@L,@M,@N,@O,@P,@Q,@R,@S,@T)", myConnection);
                SqlParameter firstParameter = new SqlParameter("@a", apkID);
                SqlParameter secondParameter = new SqlParameter("@b", apkName);
                SqlParameter thirdParameter = new SqlParameter("@c", apkVersion);
                SqlParameter forthParameter = new SqlParameter("@d", minSDK);
                SqlParameter fifthParameter = new SqlParameter("@e", packageName);
                SqlParameter sixthParameter = new SqlParameter("@f", versionNumber);
                SqlParameter seventhParemeter = new SqlParameter("@h", versionName);
                SqlParameter eighthParameter = new SqlParameter("@I", apkRiskLevel);
                SqlParameter ninthParameter = new SqlParameter("@J", testOnly);
                SqlParameter tenthParameter = new SqlParameter("@K", debuggable);
                SqlParameter eleventhParameter = new SqlParameter("@L", backup);
                SqlParameter twelvethParameter = new SqlParameter("@M", all);
                SqlParameter T13th = new SqlParameter("@N", armeabi);
                SqlParameter T14th = new SqlParameter("@O", armeabi_v7a);
                SqlParameter T15th = new SqlParameter("@P", x86_64);
                SqlParameter T16th = new SqlParameter("@Q", x86);
                SqlParameter T17th = new SqlParameter("@R", x86_64);
                SqlParameter T18th = new SqlParameter("@S", mips);
                SqlParameter T19th = new SqlParameter("@T", mips64);
                myCommand.Parameters.Add(firstParameter);
                myCommand.Parameters.Add(secondParameter);
                myCommand.Parameters.Add(thirdParameter);
                myCommand.Parameters.Add(forthParameter);
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
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
    }
}