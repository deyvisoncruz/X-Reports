using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MineHControlReports.Reports
{
    public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {
        private string UserName = string.Empty;
        private string PassWord = string.Empty;
        private string DomainName = string.Empty;
        public CustomReportCredentials(string userName, string passWord, string domainName)
        {
            UserName = userName;
            PassWord = passWord;
            DomainName = domainName;
        }
        public CustomReportCredentials(string userName, string passWord)
            : this(userName, passWord, string.Empty)
        {
            UserName = userName;
            PassWord = passWord;
        }

        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = authority = password = null;
            return false;
        }

        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        public System.Net.ICredentials NetworkCredentials
        {
            get
            {
                return new System.Net.NetworkCredential(UserName, PassWord, DomainName);
            }
        }
    }
}
