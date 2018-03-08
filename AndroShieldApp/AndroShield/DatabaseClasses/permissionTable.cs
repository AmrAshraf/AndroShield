using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroApp
{
    public class permissionTable
    {
        private string name;
        private int ID;
        public permissionTable() { }
        public permissionTable( int id,string name)
        {
            this.ID = id;
            this.name = name;
        }
        static public permissionTable addNewPermission(string name)
        {
            databaseLayer.myConnection.Open();
            SqlCommand checkExistenceOfPermission = new SqlCommand("select permissionID from permission where  name=@x", databaseLayer.myConnection);
            SqlParameter secondParamater = new SqlParameter("@x", name);
            checkExistenceOfPermission.Parameters.Add(secondParamater);
            checkExistenceOfPermission.ExecuteNonQuery();
            SqlDataReader reader = checkExistenceOfPermission.ExecuteReader();
            if (reader.Read())
            {
                reader.Dispose();
                databaseLayer.myConnection.Close();
                return null;
            }

            try
            {
                reader.Dispose();
                SqlCommand myCommand = new SqlCommand("insert into permission (name)  OUTPUT INSERTED.ID values (@c)", databaseLayer.myConnection);
                SqlParameter fifthParamater = new SqlParameter("@c", name);
                myCommand.Parameters.Add(fifthParamater);
              Int32 Num=(Int32)  myCommand.ExecuteScalar();
                permissionTable permission = new permissionTable(Num, name);
                databaseLayer.myConnection.Close();
                return permission;
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
                SqlCommand myCommand = new SqlCommand("Delete from permission where permissionID=@y", databaseLayer.myConnection);
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