using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APKInfoExtraction;
using TaintAnalysis;
using Types;
using System.Diagnostics;
using System.Threading;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string apkPath = "D:\\gp\\apks\\wasla.apk"; //this apk name will be changed to a time + .apk file name
            Thread t = new Thread(() => analyzeApk(apkPath));
            t.Start();
   
        }
        void analyzeApk(string apkPath)
        {
           
            APKInfoExtractor apkInfoExtrator = new APKInfoExtractor(apkPath); //after this line the apk name changed
            apkInfoExtrator.startExtraction();

            //here you can take information you need from apkInfoExtrator object
            TaintAnalyser taintAnalyser = new TaintAnalyser(apkInfoExtrator.realApkPath);
            //here you can take information you need from taintAnalyser object
        }
    }
}