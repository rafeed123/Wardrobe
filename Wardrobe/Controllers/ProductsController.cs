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
    public class ProductsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Products
        public ActionResult Index()
        {
            var productsTables = db.ProductsTables.Include(p => p.AccessoriesTable).Include(p => p.BottomsTable).Include(p => p.ProductTypeTable).Include(p => p.ShoesTable).Include(p => p.TopsTable);
            return View(productsTables.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsTable productsTable = db.ProductsTables.Find(id);
            if (productsTable == null)
            {
                return HttpNotFound();
            }
            return View(productsTable);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.AccesoryID = new SelectList(db.AccessoriesTables, "AccessoryID", "Name");
            ViewBag.BottomID = new SelectList(db.BottomsTables, "BottomID", "Name");
            ViewBag.ProductTypeID = new SelectList(db.ProductTypeTables, "ProductTypeID", "ProductType");
            ViewBag.ShoeID = new SelectList(db.ShoesTables, "ShoeID", "Name");
            ViewBag.TopID = new SelectList(db.TopsTables, "TopID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductTypeID,TopID,BottomID,ShoeID,AccesoryID,PhotoLink")] ProductsTable productsTable)
        {
            if (ModelState.IsValid)
            {
                db.ProductsTables.Add(productsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccesoryID = new SelectList(db.AccessoriesTables, "AccessoryID", "Name", productsTable.AccesoryID);
            ViewBag.BottomID = new SelectList(db.BottomsTables, "BottomID", "Name", productsTable.BottomID);
            ViewBag.ProductTypeID = new SelectList(db.ProductTypeTables, "ProductTypeID", "ProductType", productsTable.ProductTypeID);
            ViewBag.ShoeID = new SelectList(db.ShoesTables, "ShoeID", "Name", productsTable.ShoeID);
            ViewBag.TopID = new SelectList(db.TopsTables, "TopID", "Name", productsTable.TopID);
            return View(productsTable);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsTable productsTable = db.ProductsTables.Find(id);
            if (productsTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccesoryID = new SelectList(db.AccessoriesTables, "AccessoryID", "Name", productsTable.AccesoryID);
            ViewBag.BottomID = new SelectList(db.BottomsTables, "BottomID", "Name", productsTable.BottomID);
            ViewBag.ProductTypeID = new SelectList(db.ProductTypeTables, "ProductTypeID", "ProductType", productsTable.ProductTypeID);
            ViewBag.ShoeID = new SelectList(db.ShoesTables, "ShoeID", "Name", productsTable.ShoeID);
            ViewBag.TopID = new SelectList(db.TopsTables, "TopID", "Name", productsTable.TopID);
            return View(productsTable);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductTypeID,TopID,BottomID,ShoeID,AccesoryID,PhotoLink")] ProductsTable productsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccesoryID = new SelectList(db.AccessoriesTables, "AccessoryID", "Name", productsTable.AccesoryID);
            ViewBag.BottomID = new SelectList(db.BottomsTables, "BottomID", "Name", productsTable.BottomID);
            ViewBag.ProductTypeID = new SelectList(db.ProductTypeTables, "ProductTypeID", "ProductType", productsTable.ProductTypeID);
            ViewBag.ShoeID = new SelectList(db.ShoesTables, "ShoeID", "Name", productsTable.ShoeID);
            ViewBag.TopID = new SelectList(db.TopsTables, "TopID", "Name", productsTable.TopID);
            return View(productsTable);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsTable productsTable = db.ProductsTables.Find(id);
            if (productsTable == null)
            {
                return HttpNotFound();
            }
            return View(productsTable);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductsTable productsTable = db.ProductsTables.Find(id);
            db.ProductsTables.Remove(productsTable);
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
