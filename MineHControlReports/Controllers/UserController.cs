using MineHControlReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MineHControlReports.Controllers
{
    public class UserController : Controller
    {

        public userRepository ur = new userRepository();
        public roleRepository r = new roleRepository();
        //
        // GET: /User/

        public ActionResult Index()
        {
            var lk = ur.GetAll();
            
            return View(lk);
        }


        public ActionResult Create(string erro= "")
        {
            IList<role> ilm = r.GetAll().ToList();
            ViewBag.roleref = ilm;
            ViewBag.Error = erro;
            return View();
        }

        //
        // POST: /User/Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(user user)
        {
            try
            {
                var senhaCriptografada = Criptografic.Codifica(user.Password);
                user.Password = senhaCriptografada;
                user.Login = user.Login.Trim();
                var numUser = ur.GetAll().Where(x=>x.Login == user.Login).Count();
                if (numUser > 0)
                {
                    string error = "Já existe este login no sistema";
                    return RedirectToAction("Create", new { erro = error });
                }
                else
                {
                    ur.Save(user);
                    return RedirectToAction("Index");
                }
            }
            catch 
            {
                return View();
            }
        }

        //
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Message = "Editar User";
            IList<role> ilm = r.GetAll().ToList();
            ViewBag.roleref = ilm;
            user user = ur.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /menu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(user user)
        {

            try
            {
                ViewBag.Message = "Editar User";
                IList<role> ilm = r.GetAll().ToList();
                ViewBag.roleref = ilm;
                user.Login = user.Login.Trim();
                var senhaCriptografada = Criptografic.Codifica(user.Password);
                user.Password = senhaCriptografada;

                var numUser = ur.GetAll().Where(x => x.Login == user.Login &&  x.Id != user.Id).Count();
                if (numUser > 0)
                {
                   
                    ViewBag.error= "Já existe este login no sistema";
                    return   View("Edit",user);
                }
                else
                {
                    ur.Update(user);
                    return RedirectToAction("Index");
                }

               

            }
            catch (Exception)
            {

                return View(user);
            }


        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ViewBag.Message = "Remover user";
            user user = ur.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /menu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = ur.Get(id);
            ur.Delete(user);
            return RedirectToAction("Index");
        }



    }
}
