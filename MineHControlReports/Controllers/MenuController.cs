using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineHControlReports.Controllers
{
    public class MenuController : Controller
    {
        public menuRepository rmenu = new menuRepository();
        //
        // GET: /Menu/
       
        public ActionResult Index()
        {
            var lk = rmenu.GetAll();
            return View(lk);
            ;
        }

        //
        // GET: /Menu/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(menu m)
        {
            try
            {
                rmenu.Save(m);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Message = "Editar Menu";

            menu menu = rmenu.Get(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        //
        // POST: /menu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(menu menu)
        {

            try
            {
                rmenu.Update(menu);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(menu);
            }


        }
        public ActionResult Details(int id = 0)
        {

            ViewBag.Message = "Detalhes do menu";
            menu menu = rmenu.Get(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        public ActionResult Delete(int id = 0)
        {
            ViewBag.Message = "Remover menu";
            menu menu = rmenu.Get(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        //
        // POST: /menu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            menu menu = rmenu.Get(id);
            rmenu.Delete(menu);
            return RedirectToAction("Index");
        }


    }
}
