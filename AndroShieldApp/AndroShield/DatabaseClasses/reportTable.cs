using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroApp
{
    public class reportTable
    {
        private int reportID, apkInfoID, userAccountID;
        private string reportDate;
        bool staticallyAnalyzed, dynamicallyAnalyzed;
        public reportTable()
        {

        }
        public reportTable (int reportID, int apkInfoID, int userAccountID, string reportDate, bool staticallyAnalyzed, bool dynamicallyAnalyzed)
        {
            this.reportID = reportID;
            this.apkInfoID = apkInfoID;
            this.userAccountID = userAccountID;
            this.reportID = reportID;
            this.staticallyAnalyzed = staticallyAnalyzed;
            this.dynamicallyAnalyzed = dynamicallyAnalyzed;
            
        }
    }
}