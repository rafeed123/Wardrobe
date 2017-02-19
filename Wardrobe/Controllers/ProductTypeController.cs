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
    public class ProductTypeController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: ProductType
        public ActionResult Index()
        {
            return View(db.ProductTypeTables.ToList());
        }

        // GET: ProductType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypeTable productTypeTable = db.ProductTypeTables.Find(id);
            if (productTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(productTypeTable);
        }

        // GET: ProductType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductTypeID,ProductType")] ProductTypeTable productTypeTable)
        {
            if (ModelState.IsValid)
            {
                db.ProductTypeTables.Add(productTypeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productTypeTable);
        }

        // GET: ProductType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypeTable productTypeTable = db.ProductTypeTables.Find(id);
            if (productTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(productTypeTable);
        }

        // POST: ProductType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductTypeID,ProductType")] ProductTypeTable productTypeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTypeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productTypeTable);
        }

        // GET: ProductType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypeTable productTypeTable = db.ProductTypeTables.Find(id);
            if (productTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(productTypeTable);
        }

        // POST: ProductType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductTypeTable productTypeTable = db.ProductTypeTables.Find(id);
            db.ProductTypeTables.Remove(productTypeTable);
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
