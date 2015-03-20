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
    public class CadastroPrecosController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /CadastroPrecos/

        public ActionResult Index()
        {
            var preco = db.PRECO.Include(p => p.DDD).Include(p => p.DDD1);
            return View(preco.ToList());
        }

        //
        // GET: /CadastroPrecos/Details/5

        public ActionResult Details(int id = 0)
        {
            PRECO preco = db.PRECO.Find(id);
            if (preco == null)
            {
                return HttpNotFound();
            }
            return View(preco);
        }

        //
        // GET: /CadastroPrecos/Create

        public ActionResult Create()
        {
            ViewBag.PRECO_IDORIGEM = new SelectList(db.DDD.Where(p => p.DDD_ATIVO), "DDD_ID", "DDD_CODIGO");
            ViewBag.PRECO_IDDESTINO = new SelectList(db.DDD.Where(p => p.DDD_ATIVO), "DDD_ID", "DDD_CODIGO");
            return View();
        }

        //
        // POST: /CadastroPrecos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PRECO preco)
        {
            if (ModelState.IsValid)
            {
                db.PRECO.Add(preco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRECO_IDORIGEM = new SelectList(db.DDD.Where(p => p.DDD_ATIVO), "DDD_ID", "DDD_CODIGO", preco.PRECO_IDORIGEM);
            ViewBag.PRECO_IDDESTINO = new SelectList(db.DDD.Where(p => p.DDD_ATIVO), "DDD_ID", "DDD_CODIGO", preco.PRECO_IDDESTINO);
            return View(preco);
        }

        //
        // GET: /CadastroPrecos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PRECO preco = db.PRECO.Find(id);
            if (preco == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRECO_IDORIGEM = new SelectList(db.DDD.Where(p => p.DDD_ATIVO), "DDD_ID", "DDD_CODIGO", preco.PRECO_IDORIGEM);
            ViewBag.PRECO_IDDESTINO = new SelectList(db.DDD.Where(p => p.DDD_ATIVO), "DDD_ID", "DDD_CODIGO", preco.PRECO_IDDESTINO);
            return View(preco);
        }

        //
        // POST: /CadastroPrecos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PRECO preco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRECO_IDORIGEM = new SelectList(db.DDD.Where(p => p.DDD_ATIVO), "DDD_ID", "DDD_CODIGO", preco.PRECO_IDORIGEM);
            ViewBag.PRECO_IDDESTINO = new SelectList(db.DDD.Where(p => p.DDD_ATIVO), "DDD_ID", "DDD_CODIGO", preco.PRECO_IDDESTINO);
            return View(preco);
        }

        //
        // GET: /CadastroPrecos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PRECO preco = db.PRECO.Find(id);
            if (preco == null)
            {
                return HttpNotFound();
            }
            return View(preco);
        }

        //
        // POST: /CadastroPrecos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRECO preco = db.PRECO.Find(id);
            db.PRECO.Remove(preco);
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