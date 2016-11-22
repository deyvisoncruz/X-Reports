using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineHControlReports.Controllers
{
    public class ParameterController : Controller
    {
        public parameterRepository rparam = new parameterRepository();
        public ActionResult Index()
        {

            var lk = rparam.GetAll();
            return View(lk);


        }

        //
        // GET: /parameter/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(parameter parameter)
        {
            try
            {
                rparam.Save(parameter);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id = 0)
        {
            ViewBag.Message = "Editar Parameter";

            parameter parameter = rparam.Get(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        //
        // POST: /parameters/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(parameter parameter)
        {

            try
            {
                rparam.Update(parameter);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(parameter);
            }


        }
        public ActionResult Details(int id = 0)
        {

            ViewBag.Message = "Detalhes do Parametro";
            parameter parameter = rparam.Get(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        public ActionResult Delete(int id = 0)
        {
            ViewBag.Message = "Remover Parâmetros";
            parameter parameter = rparam.Get(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        //
        // POST: /parameters/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            parameter parameter = rparam.Get(id);
            rparam.Delete(parameter);
            return RedirectToAction("Index");
        }




    }
}
