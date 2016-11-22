using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineHControlReports.Controllers
{
    public class MenuReportController : Controller
    {
        //
        // GET: /MenuReport/
        public menuReportRepository mrr = new menuReportRepository();
        public menuRepository mr = new menuRepository();
        public ActionResult Index()
        {

            var lk = mrr.GetAll();
            
            return View(lk);
        }


        public ActionResult Create()
        {
            
            IList<menu> ilm = mr.GetAll().ToList();
            ViewBag.menuref = ilm;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(menuReport menuReport)
        {
            try
            {
               
                mrr.Save(menuReport);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Details(int id = 0)
        {

            ViewBag.Message = "Detalhes do Relatório";
            menuReport menuReport = mrr.Get(id);
            if (menuReport == null)
            {
                return HttpNotFound();
            }
            return View(menuReport);
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Message = "Editar Menu";
            IList<menu> ilm = mr.GetAll().ToList();
            ViewBag.menuref = ilm;
            menuReport menuReport = mrr.Get(id);
            if (menuReport == null)
            {
                return HttpNotFound();
            }
            return View(menuReport);
        }

        //
        // POST: /menu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(menuReport menuReport)
        {

            try
            {
                mrr.Update(menuReport);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(menuReport);
            }


        }


        public ActionResult Delete(int id = 0)
        {
            ViewBag.Message = "Remover menu";
            menuReport menuReport = mrr.Get(id);
            if (menuReport == null)
            {
                return HttpNotFound();
            }
            return View(menuReport);
        }

        //
        // POST: /menu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            menuReport menuReport = mrr.Get(id);
            mrr.Delete(menuReport);
            return RedirectToAction("Index");
        }
    }
}
