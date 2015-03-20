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
    public class CadastroPlanosController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /CadastroPlanos/

        public ActionResult Index()
        {
            return View(db.PLANO.ToList());
        }

        //
        // GET: /CadastroPlanos/Details/5

        public ActionResult Details(int id = 0)
        {
            PLANO plano = db.PLANO.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        //
        // GET: /CadastroPlanos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CadastroPlanos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PLANO plano)
        {
            if (ModelState.IsValid)
            {
                db.PLANO.Add(plano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plano);
        }

        //
        // GET: /CadastroPlanos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PLANO plano = db.PLANO.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        //
        // POST: /CadastroPlanos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PLANO plano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plano);
        }

        //
        // GET: /CadastroPlanos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PLANO plano = db.PLANO.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        //
        // POST: /CadastroPlanos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PLANO plano = db.PLANO.Find(id);
            db.PLANO.Remove(plano);
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