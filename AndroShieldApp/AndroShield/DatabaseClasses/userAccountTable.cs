using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace AndroApp
{
    public class userAccountTable
    {
        public string email, password, firstName, lastName;
        public DateTime lastLoginDate;
        public int ID;
        public userAccountTable()
        {
        }
        public userAccountTable(int Id, DateTime lastLoginDate, string password, string email, string firstName, string lastName)
        {
            this.ID = Id;
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastLoginDate = lastLoginDate;
            this.lastName = lastName;
        }
        static public bool createUserAccount(string email, string password, string firstName, string lastName, DateTime lastLoginDate)
        {
            databaseLayer.myConnection.Open();
            SqlCommand checkExistenceOfUser = new SqlCommand("select userID from userAccount where email=@y", databaseLayer.myConnection);
            SqlParameter Paramater = new SqlParameter("@y", email);
            checkExistenceOfUser.Parameters.Add(Paramater);
            checkExistenceOfUser.ExecuteNonQuery();
            SqlDataReader reader = checkExistenceOfUser.ExecuteReader();
            if (reader.Read())
            {
                databaseLayer.myConnection.Close();
                return false;
            }

            try
            {
                reader.Dispose();
                SqlCommand myCommand = new SqlCommand("insert into userAccount (lastLoginDate,password,email,firstName,lastName) values (@b,@c,@d,@e,@f)", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@b", lastLoginDate);
                secondParamater.SqlDbType = System.Data.SqlDbType.DateTime;
                SqlParameter thirdParamater = new SqlParameter("@c", password);
                SqlParameter forthParamater = new SqlParameter("@d", email);
                SqlParameter fifthParamater = new SqlParameter("@e", firstName);
                SqlParameter sixthParamater = new SqlParameter("@f", lastName);
                myCommand.Parameters.Add(secondParamater);
                myCommand.Parameters.Add(thirdParamater);
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
        } //tested
        static public userAccountTable userLogin(string Email, string password)
        {
            try
            {
                databaseLayer.myConnection.Open();
                SqlCommand checkExistenceOfUser = new SqlCommand("select userID from userAccount where email=@y and password=@x", databaseLayer.myConnection);
                SqlParameter Paramater = new SqlParameter("@y", Email);
                SqlParameter secondParamater = new SqlParameter("@x", password);
                checkExistenceOfUser.Parameters.Add(Paramater);
                checkExistenceOfUser.Parameters.Add(secondParamater);
                checkExistenceOfUser.ExecuteNonQuery();
                SqlDataReader reader = checkExistenceOfUser.ExecuteReader();
                if (reader.Read())
                {
                    SqlCommand myCommand = new SqlCommand("Select userID,lastLoginDate,password,email,firstName,lastName from userAccount where email=@y AND password=@z", databaseLayer.myConnection);
                    SqlParameter thirdParamater = new SqlParameter("@y", Email);
                    SqlParameter forthParamater = new SqlParameter("@z", password);
                    myCommand.Parameters.Add(thirdParamater);
                    myCommand.Parameters.Add(forthParamater);
                    reader.Dispose();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    myReader.Read();
                    Int32 userID = (Int32)myReader[0];
                    DateTime lastLoginDate = (DateTime)myReader[1];
                    String userPassword = (String)myReader[2];
                    String email = (String)myReader[3];
                    String firstName = (String)myReader[4];
                    String lastName = (String)myReader[5];
                    userAccountTable user = new userAccountTable(userID, lastLoginDate, userPassword, email, firstName, lastName);
                    reader.Dispose();
                    databaseLayer.myConnection.Close();
                    return user;
                }
            }
            catch (System.InvalidOperationException)
            {
                databaseLayer.myConnection.Close();
                return null;
            }
            databaseLayer.myConnection.Close();
            return null;

        } //tested
        public bool deleteRecord(string email)
        {
            try
            {
                databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Delete from userAccount where email=@y", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@y", email);
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
        static public List<KeyValuePair<int, string>> getReportsOfThisUser(string email)
        {
            try
            {
                databaseLayer.myConnection.Open();
                userAccountTable user = findUserByEmail(email);
                Int32 ID = user.ID;
                SqlCommand myCommand = new SqlCommand("select report.reportID, ApkInfo.apkName , ApkInfo.packageName , ApkInfo.versionCode , report.reportDate from report inner join ApkInfo on report.apkInfoID=ApkInfo.apkID where report.userAccountID=@y", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@y", ID);
                myCommand.Parameters.Add(secondParamater);
                SqlDataReader reader = myCommand.ExecuteReader();
                List<KeyValuePair< int,string>> reportsID = new List<KeyValuePair<int, string>>();
                while (reader.Read())
                {
                    
                    Int32 Id = (Int32)reader[0];
                    string concatinatedInfo = "";
                    concatinatedInfo += reader[1].ToString()+"#";
                    concatinatedInfo += reader[2].ToString() + "#";
                    concatinatedInfo += reader[3].ToString() + "#";
                    concatinatedInfo += reader[4].ToString();

                    reportsID.Add(new KeyValuePair<int, string>(Id, concatinatedInfo));
                }
                reader.Dispose();
                databaseLayer.myConnection.Close();

                return reportsID;
            }
            catch
            {
                databaseLayer.myConnection.Close();
                return null;
            }
        }
        static public userAccountTable findUserByEmail(string email)
        {
            try
            {
                bool close = false;
                if(databaseLayer.myConnection.State == System.Data.ConnectionState.Closed)
                {
                    databaseLayer.myConnection.Open();
                    close = true;
                }
                SqlCommand myCommand = new SqlCommand("Select * from userAccount where email =@y", databaseLayer.myConnection);
                SqlParameter firstParamater = new SqlParameter("@y", email);
                myCommand.Parameters.Add(firstParamater);
                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.Read())
                {
                    Int32 ID = (Int32)reader[0];
                    DateTime date = (DateTime)reader[1];
                    String password = (String)reader[2];
                    String Email = (String)reader[3];
                    String firstName = (String)reader[4];
                    String lastName = (String)reader[5];
                    userAccountTable user = new userAccountTable(ID, date, password, Email, firstName, lastName);
                    reader.Dispose();
                    if(close)
                        databaseLayer.myConnection.Close();
                    return user;
                }
                else
                {
                    if(close)
                        databaseLayer.myConnection.Close();
                    return null;
                }


            }
            catch
            {
                //databaseLayer.myConnection.Close();
                return null;
            }



        }
        public bool updateUser( DateTime lastLoginDate, string password, string email, string firstName, string lastName)
        {
            try
            {
                databaseLayer.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("update userAccount set lastLoginDate=@a,password=@b,email=@c,firstName=@d,lastName=@e where userID=@id", databaseLayer.myConnection);
                SqlParameter secondParamater = new SqlParameter("@a", lastLoginDate);
                SqlParameter thirdParamater = new SqlParameter("@b", password);
                SqlParameter forthParamater = new SqlParameter("@c", email);
                SqlParameter fifthParamater = new SqlParameter("@d", firstName);
                SqlParameter sixthParamater = new SqlParameter("@e", lastName);
                SqlParameter seventhParamater = new SqlParameter("@id", this.ID);

                myCommand.Parameters.Add(secondParamater);
                myCommand.Parameters.Add(thirdParamater);
                myCommand.Parameters.Add(forthParamater);
                myCommand.Parameters.Add(fifthParamater);
                myCommand.Parameters.Add(sixthParamater);
                myCommand.Parameters.Add(seventhParamater);
                int r=myCommand.ExecuteNonQuery();
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



