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
    public class ShoesController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Shoes
        public ActionResult Index()
        {
            return View(db.ShoesTables.ToList());
        }

        // GET: Shoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoesTable shoesTable = db.ShoesTables.Find(id);
            if (shoesTable == null)
            {
                return HttpNotFound();
            }
            return View(shoesTable);
        }

        // GET: Shoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoeID,Name,Color,Season,Occasion")] ShoesTable shoesTable)
        {
            if (ModelState.IsValid)
            {
                db.ShoesTables.Add(shoesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoesTable);
        }

        // GET: Shoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoesTable shoesTable = db.ShoesTables.Find(id);
            if (shoesTable == null)
            {
                return HttpNotFound();
            }
            return View(shoesTable);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoeID,Name,Color,Season,Occasion")] ShoesTable shoesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoesTable);
        }

        // GET: Shoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoesTable shoesTable = db.ShoesTables.Find(id);
            if (shoesTable == null)
            {
                return HttpNotFound();
            }
            return View(shoesTable);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoesTable shoesTable = db.ShoesTables.Find(id);
            db.ShoesTables.Remove(shoesTable);
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
