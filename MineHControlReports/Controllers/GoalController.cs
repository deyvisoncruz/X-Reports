using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineHControlReports.Controllers
{
    public class GoalController : Controller
    {
        //
        // GET: /Goal/

        public goalRepository ur = new goalRepository();
        public kpisRepository kr = new kpisRepository();
       
        public ActionResult Index()
        {
            var list = new[]
                {
                new SelectListItem { Value = "2", Text = "Equipamento" },
                new SelectListItem { Value = "1", Text = "Grupo de Equipamento" },
                new SelectListItem { Value = "0", Text = "Tipo de Equipamento" },
                };

            ViewBag.Lista = new SelectList(list, "Value", "Text");
            var vur = ur.GetAll();
            return View(vur);
        }


        public ActionResult Create()
        {
            IList<kpis> ilm = kr.GetAll().ToList();
            ViewBag.kpisref = ilm;

            
            var list = new[]
                {
                new SelectListItem { Value = "2", Text = "Equipamento" },
                new SelectListItem { Value = "1", Text = "Grupo de Equipamento" },
                new SelectListItem { Value = "0", Text = "Tipo de Equipamento" },
                };

            ViewBag.Lista = new SelectList(list, "Value", "Text");
            

            return View();
        }

        //
        // POST: /User/Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(goal goal)
        {
            try
            {
                ur.Save(goal);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult listaEntidades(int id)
        {
            equipamentsRepository er = new equipamentsRepository();
            IList<equipaments> tipo = er.GetAll().ToList();

            equipament_groupsRepository eg = new equipament_groupsRepository();
            IList<equipament_groups> grupo = eg.GetAll().ToList();

            group_equipament_linksRepository l = new group_equipament_linksRepository();
            IList<group_equipament_links> gel = l.GetAll();



            var data = tipo.Select(m => new { m.Id, m.Name }).ToList();
            var data1 = grupo.Select(m => new { m.Id, m.Name }).ToList();
            var data2 = gel.Select(m => new { m.Id, m.Name }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
