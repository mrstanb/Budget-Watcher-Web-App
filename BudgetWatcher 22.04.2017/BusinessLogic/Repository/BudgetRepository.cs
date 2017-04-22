using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.DBContextDomain;
using System.Data.Entity;

namespace BusinessLogic.Repository
{
    public class BudgetRepository : IBudgetRepository
    {
        private Budget budget = new Budget();

        public void Add(Budget item)
        {
            budget.InitialBalance = item.InitialBalance;
            budget.StartDate = item.StartDate;
            budget.EndDate = item.EndDate;
            budget.Balance = item.InitialBalance;

            using (var context = new BudgetWatcherContext())
            {
                context.Budgets.Add(budget);
            }
        }

        public void ChangeBalance(Budget item)
        {
            budget = GetById(item.Id);
            if (budget == null)
            {
                throw new ArgumentNullException("Budget not found");
            }
            budget.Balance = item.Balance;

            using (var context = new BudgetWatcherContext())
            {
                context.Budgets.Attach(budget);
                context.Entry(budget).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Budget item)
        {
            budget = GetById(item.Id);

            if (budget == null)
            {
                throw new ArgumentNullException("Budget not found");
            }

            using (var context = new BudgetWatcherContext())
            {
                context.Budgets.Attach(budget);
                context.Budgets.Remove(budget);
                context.SaveChanges();
            }
        }

        public ICollection<Budget> GetAll()
        {
            ICollection<Budget> budgets = new HashSet<Budget>();
            using (var context = new BudgetWatcherContext())
            {
                budgets = context.Budgets.ToList();
            }
            return budgets;
        }

        public Budget GetById(int id)
        {
            using (var context = new BudgetWatcherContext())
            {
                budget = context.Budgets.FirstOrDefault(x => x.Id == id);
            }

            if (budget == null)
            {
                throw new ArgumentNullException("Budget not found");
            }

            return budget;
        }

        public decimal GetBalance(Budget item)
        {
            decimal balance;
            using (var context = new BudgetWatcherContext())
            {
                balance = context.Budgets.FirstOrDefault(x => x.Id == item.Id).Balance;
            }

            return balance;
        }

        public void Update(Budget item)
        {
            budget = GetById(item.Id);
            if (budget == null)
            {
                throw new ArgumentNullException("Budget not found");
            }
            budget.StartDate = item.StartDate;
            budget.EndDate = item.EndDate;
            budget.InitialBalance = item.InitialBalance;
            budget.Balance = item.InitialBalance;

            using (var context = new BudgetWatcherContext())
            {
                context.Budgets.Attach(budget);
                context.Entry(budget).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}