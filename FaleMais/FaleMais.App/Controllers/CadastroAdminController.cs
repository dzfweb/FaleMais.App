using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaleMais.Models;
using FaleMais.Repositorio;

namespace FaleMais.App.Controllers
{
    [Authorize]
    public class CadastroAdminController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /CadastroAdmin/

        public ActionResult Index()
        {
            return View(db.ADMIN.ToList());
        }

        //
        // GET: /CadastroAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            ADMIN admin = db.ADMIN.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // GET: /CadastroAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CadastroAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ADMIN admin)
        {
            if (ModelState.IsValid)
            {
                db.ADMIN.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        //
        // GET: /CadastroAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ADMIN admin = db.ADMIN.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /CadastroAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ADMIN admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //
        // GET: /CadastroAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ADMIN admin = db.ADMIN.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /CadastroAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADMIN admin = db.ADMIN.Find(id);
            db.ADMIN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}