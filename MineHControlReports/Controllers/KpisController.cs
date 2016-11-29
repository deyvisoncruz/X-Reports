using System;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using MineHControlReports.Models;
using MineHControlReports.Dao;
using System.Collections.Generic;
namespace MineHControlReports.Controllers
{
    public class KpisController : Controller
    {
        //
        // GET: /Kpis/
        
        public kpisRepository rkpi = new kpisRepository();
        [Authorize]
        public ActionResult Index()
        {
             
                var lk = rkpi.GetAll();
                return View(lk);
            
            
        }

        //
        // GET: /Kpis/Create
        [Authorize]
        public ActionResult Create()
        {
                return View();            
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(kpis kpis)
        {
            try
            {
                rkpi.Save(kpis);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Message = "Editar Kpi";
             
             kpis kpis = rkpi.Get(id);
            if (kpis == null)
            {
                return HttpNotFound();
            }
            return View(kpis);
        }

        //
        // POST: /Kpis/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(kpis kpis)
        {

            try
            {
                rkpi.Update(kpis);
                return RedirectToAction("Index");
            
            }
            catch (Exception)
            {

                return View(kpis);
            }
               
           
        }
        public ActionResult Details(int id = 0)
        {

            ViewBag.Message = "Detalhes do Kpi";
            kpis kpis = rkpi.Get(id);
            if (kpis == null)
            {
                return HttpNotFound();
            }
            return View(kpis);
        }

        public ActionResult Delete(int id = 0)
        {
            ViewBag.Message = "Remover Kpis";
            kpis kpis = rkpi.Get(id);
            if (kpis == null)
            {
                return HttpNotFound();
            }
            return View(kpis);
        }

        //
        // POST: /Kpis/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kpis kpis = rkpi.Get(id);
            rkpi.Delete(kpis);           
            return RedirectToAction("Index");
        }

       
    }
}
