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
using BusinessLogic.Repository;

namespace BudgetWatcherMVC.Controllers
{
    [Authorize]
    public class BudgetController : Controller
    {
        private BudgetWatcherContext db = new BudgetWatcherContext();
        private BudgetRepository repo = new BudgetRepository();

        // GET: Budget
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Budget/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = repo.GetById(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // GET: Budget/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Budget/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InitialBalance,StartDate,EndDate")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                repo.Add(budget);
                return RedirectToAction("Index");
            }

            return View(budget);
        }

        // GET: Budget/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = repo.GetById(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // POST: Budget/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InitialBalance,StartDate,EndDate")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                repo.Update(budget);
                return RedirectToAction("Index");
            }
            return View(budget);
        }

        // GET: Budget/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = repo.GetById(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // POST: Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Budget budget = repo.GetById(id);
            repo.Delete(budget);
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
