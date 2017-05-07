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
    public class SpendingController : Controller
    {
        private BudgetWatcherContext db = new BudgetWatcherContext();
        private SpendingRepository repo = new SpendingRepository();
        // GET: Spending
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Spending/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spending spending = repo.GetById(id);
            if (spending == null)
            {
                return HttpNotFound();
            }
            return View(spending);
        }

        // GET: Spending/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spending/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,SpendingDate,MoneySpent")] Spending spending)
        {
            if (ModelState.IsValid)
            {
                repo.Add(spending);
                return RedirectToAction("Index");
            }

            return View(spending);
        }

        // GET: Spending/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spending spending = repo.GetById(id);
            if (spending == null)
            {
                return HttpNotFound();
            }
            return View(spending);
        }

        // POST: Spending/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Description,SpendingDate,MoneySpent")] Spending spending)
        {
            if (ModelState.IsValid)
            {
                repo.Update(spending);
                return RedirectToAction("Index");
            }
            return View(spending);
        }

        // GET: Spending/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spending spending = repo.GetById(id);
            if (spending == null)
            {
                return HttpNotFound();
            }
            return View(spending);
        }

        // POST: Spending/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spending spending = repo.GetById(id);
            repo.Delete(spending);
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
