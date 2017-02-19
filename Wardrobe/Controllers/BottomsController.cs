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
    public class BottomsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Bottoms
        public ActionResult Index()
        {
            return View(db.BottomsTables.ToList());
        }

        // GET: Bottoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomsTable bottomsTable = db.BottomsTables.Find(id);
            if (bottomsTable == null)
            {
                return HttpNotFound();
            }
            return View(bottomsTable);
        }

        // GET: Bottoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bottoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BottomID,Name,Color,Season,Occasion")] BottomsTable bottomsTable)
        {
            if (ModelState.IsValid)
            {
                db.BottomsTables.Add(bottomsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bottomsTable);
        }

        // GET: Bottoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomsTable bottomsTable = db.BottomsTables.Find(id);
            if (bottomsTable == null)
            {
                return HttpNotFound();
            }
            return View(bottomsTable);
        }

        // POST: Bottoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BottomID,Name,Color,Season,Occasion")] BottomsTable bottomsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottomsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bottomsTable);
        }

        // GET: Bottoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomsTable bottomsTable = db.BottomsTables.Find(id);
            if (bottomsTable == null)
            {
                return HttpNotFound();
            }
            return View(bottomsTable);
        }

        // POST: Bottoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BottomsTable bottomsTable = db.BottomsTables.Find(id);
            db.BottomsTables.Remove(bottomsTable);
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
