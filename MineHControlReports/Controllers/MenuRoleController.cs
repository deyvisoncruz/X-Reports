using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineHControlReports.Controllers
{
    public class MenuRoleController : Controller
    {
        //

        // GET: /menuRole/
        public menuRoleRepository mrr = new menuRoleRepository();
        public menuRepository mr = new menuRepository();
        public roleRepository rr = new roleRepository();
        public ActionResult Index()
        {

            var lk = mrr.GetAll();
            
            return View(lk);
        }


        public ActionResult Create()
        {
            
            IList<menu> ilm = mr.GetAll().ToList();
            ViewBag.menuref = ilm;
            IList<role> ilr = rr.GetAll().ToList();
            ViewBag.roleref = ilr;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(menuRole menuRole2)
        {

            IList<menu> ilm = mr.GetAll().ToList();
            ViewBag.menuref = ilm;
            IList<role> ilr = rr.GetAll().ToList();
            ViewBag.roleref = ilr;
            try
            {
               
                mrr.Save(menuRole2);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Details(int id = 0)
        {

           
            menuRole menuRole = mrr.Get(id);
            if (menuRole == null)
            {
                return HttpNotFound();
            }
            return View(menuRole);
        }

        public ActionResult Edit(int id = 0)
        {
            
            IList<menu> ilm = mr.GetAll().ToList();
            ViewBag.menuref = ilm;

            IList<role> ilr = rr.GetAll().ToList();
            ViewBag.roleref = ilr;

            menuRole menuRole = mrr.Get(id);
            if (menuRole == null)
            {
                return HttpNotFound();
            }
            return View(menuRole);
        }

        //
        // POST: /menu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(menuRole menuRole)
        {

            try
            {
                mrr.Update(menuRole);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(menuRole);
            }


        }


        public ActionResult Delete(int id = 0)
        {
            ViewBag.Message = "Remover menu";
            menuRole menuRole = mrr.Get(id);


            if (menuRole == null)
            {
                return HttpNotFound();
            }
            return View(menuRole);
        }

        //
        // POST: /menu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            menuRole menuRole = mrr.Get(id);
            mrr.Delete(menuRole);

            return RedirectToAction("Index");
        }
    }
    
}
