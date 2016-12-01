using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineReports.Controllers
{
    public class HomeController : Controller
    {

        private List<menuList> ml = new List<menuList>();
        private menuRepository menuR = new menuRepository();
        private menuRoleRepository menuRoleR = new menuRoleRepository();
        private menuReportRepository mRR = new menuReportRepository();
        private userRepository userR = new userRepository();
        private roleRepository roleR = new roleRepository();
        private List<menu> m = new List<menu>();
        
        private List<subMenuList> subml = new List<subMenuList>();

        public ActionResult Index(string Id = "metas", string type = "1")
        {
            if (Id != "metas")
            {
                if (type == "1")
                    ViewBag.Report = "http://localhost:25584/Reports/ReportView.aspx?report=" + Id;
                else
                    ViewBag.Report = "http://localhost/MC/reports/" + Id + ".aspx"; ;
            }
            else
            {
                ViewBag.Report = "http://localhost:25584/Reports/ReportView.aspx?report=" + Id;
            }
            return View();
        }

        public ActionResult MenuList()
        {
            var queryMenu = menuR.GetAll().OrderBy(p => p.OrderBy); ;
            string dinamicMenu = "";
            string url = "http://localhost:25584";
            
            var userRoleId =  userR.GetAll().Where(x=>x.Login ==User.Identity.Name).ToList();
            
            List<int> listRoleuId = new List<int>();

            foreach ( user u in userRoleId)
            {
                listRoleuId.Add(u.RoleId);
            }
            
            List<int> listMenuId = new List<int>();

            foreach (int i in listRoleuId)
            {

                listMenuId.AddRange(menuRoleR.GetAll().Where(x=>x.RoleId ==i).Select(x=>x.MenuId));

            }

            var listMRR = mRR.GetAll();
            foreach (menu c in queryMenu)
            {


                if (listMenuId.Contains(c.Id))
                {

                    var queryReport = listMRR.Where(p => p.MenuId == c.Id).OrderBy(p => p.OrderBy);

                    if (queryReport.Count() > 0)
                        dinamicMenu += "<li class='dropdown'>" +
                        "<a href='" + c.Link + "' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-haspopup='true' aria-expanded='false'>" + c.Name + " <span class='caret'></span></a>";
                    else
                        dinamicMenu += "<li><a href='" + c.Link + "'>" + c.Name + "</a>";

                    if (queryReport.Count() > 0)
                    {
                        dinamicMenu += " <ul class='dropdown-menu'>";
                        foreach (menuReport r in queryReport)
                        {

                            dinamicMenu += "<li><a href='" + url + "/home/index/" + r.Link + "/" + r.TypeReport + "'>" + r.Name + "</a></li>";


                        }

                        dinamicMenu += "</ul>";
                    }
                    dinamicMenu += "</li>";
                }
            }
            ViewBag.menu = dinamicMenu;
            return PartialView();
        }
    }
}
