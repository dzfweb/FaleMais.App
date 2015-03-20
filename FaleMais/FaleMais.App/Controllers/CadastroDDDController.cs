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
    public class CadastroDDDController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /CadastroDDD/

        public ActionResult Index()
        {
            return View(db.DDD.ToList());
        }

        //
        // GET: /CadastroDDD/Details/5

        public ActionResult Details(int id = 0)
        {
            DDD ddd = db.DDD.Find(id);
            if (ddd == null)
            {
                return HttpNotFound();
            }
            return View(ddd);
        }

        //
        // GET: /CadastroDDD/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CadastroDDD/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DDD ddd)
        {
            if (ModelState.IsValid)
            {
                db.DDD.Add(ddd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ddd);
        }

        //
        // GET: /CadastroDDD/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DDD ddd = db.DDD.Find(id);
            if (ddd == null)
            {
                return HttpNotFound();
            }
            return View(ddd);
        }

        //
        // POST: /CadastroDDD/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DDD ddd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ddd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ddd);
        }

        //
        // GET: /CadastroDDD/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DDD ddd = db.DDD.Find(id);
            if (ddd == null)
            {
                return HttpNotFound();
            }
            return View(ddd);
        }

        //
        // POST: /CadastroDDD/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DDD ddd = db.DDD.Find(id);
            db.DDD.Remove(ddd);
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