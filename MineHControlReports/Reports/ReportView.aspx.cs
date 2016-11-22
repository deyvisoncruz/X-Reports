using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace MineHControlReports.Reports
{
    public partial class ReportView : System.Web.UI.Page
    {
        const string REPORT_SERVER_URL = "WV_REPORT_SERVER_URL";
        const string REPORT_SERVER_USER = "WV_REPORT_SERVER_USER";
        const string REPORT_SERVER_PASSWORD = "WV_REPORT_SERVER_PASSWORD";
        const string REPORT_SERVER_DOMAIN = "WV_REPORT_SERVER_DOMAIN";
        public string reportUrlRequest;

        internal class Credentials
        {
            internal string User;
            internal string Password;
            internal string Domain;
        }

        // static AssetSubscriber subscriber = null;

        Credentials reportCredentials;
        Credentials ReportCredentials
        {
            get
            {
                if (reportCredentials == null)
                {
                    reportCredentials = new Credentials
                    {
                        User = "deyvison",
                        Password = "mariace0682",
                        Domain = "NOTEDVX247",
                    };
                }
                return reportCredentials;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reportUrlRequest = Request.QueryString["report"];
                ShowReport(reportUrlRequest);
            }
        }

        /*void ReportView_ConfigurationChanged(Models.ConfigurationDTO config, Devex.Server.Library.DataTransferObjects.Basic.ActionType action)
        {
            if (config.Folder == WebView.Controllers.ReportsController.REPORTS_CONFIG_FOLDER)
            {
                reportCredentials = null;
            }
        }*/

        private void ShowReport( string report)
        {
            try
            {
                //report url  
                string urlReportServer = "http://localhost/ReportServer";

                // ProcessingMode will be Either Remote or Local  
                rptViewer.ProcessingMode = ProcessingMode.Remote;

                //Set the ReportServer Url  
                rptViewer.ServerReport.ReportServerUrl = new Uri(urlReportServer);

                // setting report path  
                //Passing the Report Path with report name no need to add report extension   
                rptViewer.ServerReport.ReportPath = report;

                if (!rptViewer.ServerReport.ReportPath.StartsWith("/"))
                {
                    rptViewer.ServerReport.ReportPath = "/" + rptViewer.ServerReport.ReportPath;
                }

                // pass credential as if any... no need to pass anything if we use windows authentication  
                rptViewer.ServerReport.ReportServerCredentials = new CustomReportCredentials(ReportCredentials.User, ReportCredentials.Password, reportCredentials.Domain);

                rptViewer.ServerReport.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}