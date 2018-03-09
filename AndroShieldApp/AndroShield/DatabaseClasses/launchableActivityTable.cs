using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroApp
{
    public class launchableActivityTable
    {
        private int apkInfoID, activiyID;
        string name; 
        public launchableActivityTable() { }
        public launchableActivityTable( int ID, int apkInfoID, string name)
        {
            this.activiyID = ID;
            this.apkInfoID = apkInfoID;
            this.name = name; 
        }
        static public launchableActivityTable addNewActivity ( string name, int apkInfoID)
        {
            databaseLayer.myConnection.Open();
            SqlCommand checkExistenceOfActivity = new SqlCommand("select launchableActivityID from launchableActivity where name=@x and apkInfoID=@z", databaseLayer.myConnection);
            SqlParameter Paramater = new SqlParameter("@x", name);
            SqlParameter secondParamater = new SqlParameter("@z", apkInfoID);
            checkExistenceOfActivity.Parameters.Add(Paramater);
            checkExistenceOfActivity.Parameters.Add(secondParamater);
            checkExistenceOfActivity.ExecuteNonQuery();
            SqlDataReader reader = checkExistenceOfActivity.ExecuteReader();
            if (reader.Read())
            {
                reader.Dispose();
                databaseLayer.myConnection.Close();
                return null;
            }

            try
            {
                reader.Dispose();
                SqlCommand myCommand = new SqlCommand("insert into launchableActivity (name,apkInfoID)  OUTPUT INSERTED.launchableActivityID  values (@c,@d)", databaseLayer.myConnection);
                SqlParameter fifthParamater = new SqlParameter("@c", name);
                SqlParameter sixthParamater = new SqlParameter("@d", apkInfoID);
                myCommand.Parameters.Add(fifthParamater);
                myCommand.Parameters.Add(sixthParamater);
            Int32 id = (Int32) myCommand.ExecuteNonQuery();
                launchableActivityTable activity = new launchableActivityTable(id, apkInfoID, name);
                databaseLayer.myConnection.Close();
                return activity;
            }
            catch (System.Data.SqlClient.SqlException)
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
                SqlCommand myCommand = new SqlCommand("Delete from launchableActivity where launchableActivityID=@y", databaseLayer.myConnection);
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
    }
}