using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace AndroShield
{
    public class userAccountTable
    {
        private string email, password, firstName, lastName, lastLoginDate;
        private int userID;
        public userAccountTable()
        {

        }
        public userAccountTable(int userID, string lastLoginDate, string password, string email, string firstName, string lastName)
        {
            this.userID = userID;
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastLoginDate = lastLoginDate;
            this.lastName = lastName;
        }
        static public bool createUserAccount(string email, string password, string firstName, string lastName, DateTime lastLoginDate)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=AndroShield;Integrated Security=True");
            myConnection.Open();
            SqlCommand checkExistenceOfUser = new SqlCommand("select userID from userAccount where email=@y", myConnection);
            SqlParameter Paramater = new SqlParameter("@y", email);
            checkExistenceOfUser.Parameters.Add(Paramater);
            checkExistenceOfUser.ExecuteNonQuery();
            SqlDataReader reader = checkExistenceOfUser.ExecuteReader();
            if (reader.Read())
                return false;

            try
            {
                reader.Dispose();
                SqlCommand myCommand = new SqlCommand("insert into userAccount (lastLoginDate,password,email,firstName,lastName) values (@b,@c,@d,@e,@f)", myConnection);
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

                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        static public userAccountTable userLogin(string Email, string password)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=AndroShield;Integrated Security=True");
                myConnection.Open();
                SqlCommand checkExistenceOfUser = new SqlCommand("select userID from userAccount where email=@y and password=@x", myConnection);
                SqlParameter Paramater = new SqlParameter("@y", Email);
                SqlParameter secondParamater = new SqlParameter("@x", password);
                checkExistenceOfUser.Parameters.Add(Paramater);
                checkExistenceOfUser.Parameters.Add(secondParamater);
                checkExistenceOfUser.ExecuteNonQuery();
                SqlDataReader reader = checkExistenceOfUser.ExecuteReader();
                if (reader.Read())
                {
                    SqlCommand myCommand = new SqlCommand("Select userID,lastLoginDate,password,email,firstName,lastName from userAccount where email=@y AND password=@z", myConnection);
                    SqlParameter thirdParamater = new SqlParameter("@y", Email);
                    SqlParameter forthParamater = new SqlParameter("@z", password);
                    myCommand.Parameters.Add(thirdParamater);
                    myCommand.Parameters.Add(forthParamater);
                    reader.Dispose();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    myReader.Read();
                    Int32 userID = (Int32)myReader[0];
                    String lastLoginDate = myReader[1].ToString();
                    String userPassword = (String)myReader[2];
                    String email = (String)myReader[3];
                    String firstName = (String)myReader[4];
                    String lastName = (String)myReader[5];
                    userAccountTable user = new userAccountTable(userID, lastLoginDate, userPassword, email, firstName, lastName);
                    reader.Dispose();
                    return user;
                }
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
            return null;

        }
    }
}
