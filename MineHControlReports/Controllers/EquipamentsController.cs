using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineHControlReports.Controllers
{
    public class EquipamentsController : Controller
    {
        //
        // GET: /Equipaments/

        public equipamentsRepository eqtts = new equipamentsRepository();
        public ActionResult Index()
        {

            var lk = eqtts.GetAll();
                return View(lk);
            
            
        }
    }
}
