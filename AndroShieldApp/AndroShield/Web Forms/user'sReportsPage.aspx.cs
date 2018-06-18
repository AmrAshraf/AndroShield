using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroApp.Web_Forms
{
    public partial class user_sReportsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                userEmail.Text = Session["username"].ToString();
                Session["userReports"]= userAccountTable.getReportsOfThisUser(Session["username"].ToString());
                Session["apkNames"] = new List<string>();
            }

            buildReportsTable();
        }
        protected void signupNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfilePage.aspx");
        }
        protected void viewReport(object sender, EventArgs e)
        {
            Session["tempReportId"] = int.Parse(((Button)sender).ID);
            Session["reportID"] = ((List<KeyValuePair<int, string>>)Session["userReports"])[int.Parse(Session["tempReportId"].ToString())].Key;
            Session["currentReportName"] = ((List<string>)Session["apkNames"])[int.Parse(Session["tempReportId"].ToString())];
            Session.Contents.Remove("apkNames");
            Response.Redirect("reportAnalysisPage.aspx",false);
        }
        protected void deleteReport(object sender, EventArgs e)
        {
            Session["tempDeleteReportId"] = int.Parse(((Button)sender).ID.Substring(1));
            Session["deleteReportId"] = ((List<KeyValuePair<int, string>>)Session["userReports"])[int.Parse(Session["tempDeleteReportId"].ToString())].Key;
            List<KeyValuePair<int, string>> userreports = ((List<KeyValuePair<int, string>>)Session["userReports"]);

            reportTable.deleteRecord(int.Parse(Session["deleteReportId"].ToString()));
            buildReportsTable();
        }
        protected void buildReportsTable()
        {
            if(IsPostBack)
            {
                for(int i=1; i< allReportsTable.Rows.Count; i++)
                {
                    allReportsTable.Rows.RemoveAt(i);
                    i--;
                }
            }
            Session["userReports"] = userAccountTable.getReportsOfThisUser(Session["username"].ToString());

            HyperLink link = new HyperLink();
            link.NavigateUrl = "~/Web Forms/reportAnalysisPage.aspx";
            for (int i = 0; i < ((List<KeyValuePair<int, string>>)Session["userReports"]).Count; i++)
            {
                TableRow row = new TableRow();
                row.CssClass = "vulnerabilityReportTableRows";
                row.Height = 30;
                Session["reportInfo"] = ((List<KeyValuePair<int, string>>)Session["userReports"])[i].Value.Split('#');
                TableCell apkName = new TableCell();
                apkName.Controls.Add(link);
                apkName.Text = ((string[])Session["reportInfo"])[0];
                ((List<string>)Session["apkNames"]).Add(((string[])Session["reportInfo"])[0]);

                TableCell packageName = new TableCell();
                packageName.Controls.Add(link);
                packageName.Text = ((string[])Session["reportInfo"])[1];

                TableCell versionCode = new TableCell();
                versionCode.Controls.Add(link);
                versionCode.Text = ((string[])Session["reportInfo"])[2];

                TableCell date = new TableCell();
                date.Controls.Add(link);
                date.Text = ((string[])Session["reportInfo"])[3];

                TableCell viewButton = new TableCell();
                Button view = new Button();
                view.Text = "View";
                view.CssClass = "homeButtons";
                view.ID = i.ToString();
                view.Click += new EventHandler(viewReport);
                viewButton.Controls.Add(view);

                TableCell deleteButton = new TableCell();
                Button delete = new Button();
                delete.Text = "Delete";
                delete.CssClass = "homeButtons";
                delete.ID = "d" + i.ToString();
                delete.Click += new EventHandler(deleteReport);
                deleteButton.Controls.Add(delete);

                row.Cells.Add(apkName);
                row.Cells.Add(packageName);
                row.Cells.Add(versionCode);
                row.Cells.Add(date);
                row.Cells.Add(viewButton);
                row.Cells.Add(deleteButton);

                allReportsTable.Rows.Add(row);

                Session.Contents.Remove("reportInfo");
            }
        }
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Cookies.Clear();
            Request.Cookies.Clear();

            Session.Abandon();
            Response.Redirect("homePage.aspx");
        }
    }
}