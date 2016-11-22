using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineHControlReports.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        //
        // GET: /role/
        public roleRepository rrole = new roleRepository();
        public ActionResult Index()
        {

            var lk = rrole.GetAll();
            return View(lk);


        }

        //
        // GET: /role/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(role role)
        {
            try
            {
                rrole.Save(role);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Message = "Editar Role";

            role role = rrole.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /role/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(role role)
        {

            try
            {
                rrole.Update(role);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(role);
            }


        }
        public ActionResult Details(int id = 0)
        {

            ViewBag.Message = "Detalhes do Role";
            role role = rrole.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        public ActionResult Delete(int id = 0)
        {
            ViewBag.Message = "Remover role";
            role role = rrole.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /role/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            role role = rrole.Get(id);
            rrole.Delete(role);
            return RedirectToAction("Index");
        }

       

    }
}
