using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe.Models;

namespace Wardrobe.Controllers
{
    public class TopsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Tops
        public ActionResult Index()
        {
            return View(db.TopsTables.ToList());
        }

        // GET: Tops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopsTable topsTable = db.TopsTables.Find(id);
            if (topsTable == null)
            {
                return HttpNotFound();
            }
            return View(topsTable);
        }

        // GET: Tops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopID,Name,Color,Season,Occasion")] TopsTable topsTable)
        {
            if (ModelState.IsValid)
            {
                db.TopsTables.Add(topsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topsTable);
        }

        // GET: Tops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopsTable topsTable = db.TopsTables.Find(id);
            if (topsTable == null)
            {
                return HttpNotFound();
            }
            return View(topsTable);
        }

        // POST: Tops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopID,Name,Color,Season,Occasion")] TopsTable topsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topsTable);
        }

        // GET: Tops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopsTable topsTable = db.TopsTables.Find(id);
            if (topsTable == null)
            {
                return HttpNotFound();
            }
            return View(topsTable);
        }

        // POST: Tops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopsTable topsTable = db.TopsTables.Find(id);
            db.TopsTables.Remove(topsTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
