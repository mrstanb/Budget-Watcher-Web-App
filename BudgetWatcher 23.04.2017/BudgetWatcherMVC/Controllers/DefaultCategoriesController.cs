using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.DBContextDomain;
using BusinessLogic.Entities;

namespace BudgetWatcherMVC.Controllers
{
    public class DefaultCategoriesController : Controller
    {
        private BudgetWatcherContext db = new BudgetWatcherContext();

        // GET: DefaultCategories
        public ActionResult Index()
        {
            return View(db.DefaultCategories.ToList());
        }

        // GET: DefaultCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefaultCategory defaultCategory = db.DefaultCategories.Find(id);
            if (defaultCategory == null)
            {
                return HttpNotFound();
            }
            return View(defaultCategory);
        }

        // GET: DefaultCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DefaultCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DefaultCategory defaultCategory)
        {
            if (ModelState.IsValid)
            {
                db.DefaultCategories.Add(defaultCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defaultCategory);
        }

        // GET: DefaultCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefaultCategory defaultCategory = db.DefaultCategories.Find(id);
            if (defaultCategory == null)
            {
                return HttpNotFound();
            }
            return View(defaultCategory);
        }

        // POST: DefaultCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DefaultCategory defaultCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defaultCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defaultCategory);
        }

        // GET: DefaultCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefaultCategory defaultCategory = db.DefaultCategories.Find(id);
            if (defaultCategory == null)
            {
                return HttpNotFound();
            }
            return View(defaultCategory);
        }

        // POST: DefaultCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DefaultCategory defaultCategory = db.DefaultCategories.Find(id);
            db.DefaultCategories.Remove(defaultCategory);
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
