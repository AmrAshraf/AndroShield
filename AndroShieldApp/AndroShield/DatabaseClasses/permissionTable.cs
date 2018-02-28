using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AndroShield
{
    public class permissionTable
    {
        private int permissionID;
        private string name;
        public permissionTable() { }
        public permissionTable(int permissionID, string name)
        {
            this.permissionID = permissionID;
            this.name = name;
        }
    }
}