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
    public class AccessoriesController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Accessories
        public ActionResult Index()
        {
            return View(db.AccessoriesTables.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoriesTable accessoriesTable = db.AccessoriesTables.Find(id);
            if (accessoriesTable == null)
            {
                return HttpNotFound();
            }
            return View(accessoriesTable);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessoryID,Name,Color,Season,Occason")] AccessoriesTable accessoriesTable)
        {
            if (ModelState.IsValid)
            {
                db.AccessoriesTables.Add(accessoriesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessoriesTable);
        }

        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoriesTable accessoriesTable = db.AccessoriesTables.Find(id);
            if (accessoriesTable == null)
            {
                return HttpNotFound();
            }
            return View(accessoriesTable);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessoryID,Name,Color,Season,Occason")] AccessoriesTable accessoriesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessoriesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessoriesTable);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoriesTable accessoriesTable = db.AccessoriesTables.Find(id);
            if (accessoriesTable == null)
            {
                return HttpNotFound();
            }
            return View(accessoriesTable);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessoriesTable accessoriesTable = db.AccessoriesTables.Find(id);
            db.AccessoriesTables.Remove(accessoriesTable);
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
