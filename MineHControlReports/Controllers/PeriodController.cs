using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineHControlReports.Controllers
{
    public class PeriodController : Controller
    {
        //
        // GET: /Period/
        public periodRepository rperiod = new periodRepository();
        
        public ActionResult Index()
        {
            var lk = rperiod.GetAll();
            return View(lk);
            
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(period period)
        {
            try
            {
                rperiod.Save(period);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Message = "Editar Período";

            period period = rperiod.Get(id);
            if (period == null)
            {
                return HttpNotFound();
            }
            return View(period);
        }

        //
        // POST: /period/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(period period)
        {

            try
            {
                rperiod.Update(period);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(period);
            }


        }
        public ActionResult Delete(int id = 0)
        {
            ViewBag.Message = "Remover Período";
            period period = rperiod.Get(id);
            if (period == null)
            {
                return HttpNotFound();
            }
            return View(period);
        }

        //
        // POST: /period/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            period period = rperiod.Get(id);
            rperiod.Delete(period);
            return RedirectToAction("Index");
        }
    }



}
