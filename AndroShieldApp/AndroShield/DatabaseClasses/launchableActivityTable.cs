using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroApp
{
    public class launchableActivityTable
    {
        private int launchableActivityID, apkInfoID;
        string name; 
        public launchableActivityTable() { }
        public launchableActivityTable(int launchableActivityID, int apkInfoID, string name)
        {
            this.launchableActivityID = launchableActivityID;
            this.apkInfoID = apkInfoID;
            this.name = name; 
        }
    }
}