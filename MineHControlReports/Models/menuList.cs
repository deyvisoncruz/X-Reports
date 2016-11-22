using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MineHControlReports.Models
{
    public class menuList
    {
        public string menuLabel { get; set; }
        public string menuLink { get; set; }


        public menuList(string m1, string l1)
        {
            menuLabel = m1;
            menuLink = l1;
        }

        public menuList()
        {
            // TODO: Complete member initialization
        }
    }

    public class subMenuList
    {
        public string menuLabel { get; set; }
        public string menuLink { get; set; }
        public string reportLabel { get; set; }
        public string reportLink { get; set; }

        public subMenuList(string m1, string l1, string m2, string l2)
        {
            menuLabel = m1;
            menuLink = l1;
            reportLabel = m2;
            reportLink = l2;
        }

    }
}