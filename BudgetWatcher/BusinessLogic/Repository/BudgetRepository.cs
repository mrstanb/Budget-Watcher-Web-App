using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.DBContextDomain;

namespace BusinessLogic.Repository
{
    public class BudgetRepository : IBudgetRepository
    {
        private Budget budget = new Budget();
        private SpendingCategory spendingCategory = new SpendingCategory();
        private SpendingCategoryRepository spendingCategoryRepo = new SpendingCategoryRepository();

        public void Add(Budget item)
        {
            budget.InitialBudget = item.InitialBudget;
            budget.StartDate = item.StartDate;
            budget.EndDate = item.EndDate;
            budget.TotalLeft = item.InitialBudget;

            using(var context = new BudgetWatcherContext())
            {
                context.Budgets.Add(budget);
            }
        }

        // TO DO
        public void AddTotalPriceChanges(Budget budgetItem)
        {
           // spendingCategory = spendingCategoryRepo.GetById(itemCategory.Id);
            budget = GetById(budgetItem.Id);
            //budget.Spendings.
            if(spendingCategory == null)
            {
                throw new ArgumentNullException("Category doesn't exist");
            }

            if(budget == null)
            {
                throw new ArgumentNullException("Budget not found");
            }

            budget.TotalLeft = budget.TotalLeft - spendingCategory.MoneySpent;
        }

        public void Delete(Budget item)
        {
            budget = GetById(item.Id);

            if(budget == null)
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
            using(var context = new BudgetWatcherContext())
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

            if(budget == null)
            {
                throw new ArgumentNullException("Budget not found");
            }

            return budget;
        }

        public decimal GetTotal(Budget item)
        {
            decimal totalLeft;
            using(var context = new BudgetWatcherContext())
            {
                totalLeft = context.Budgets.FirstOrDefault(x => x.Id == item.Id).TotalLeft;
            }

            return totalLeft;
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
            budget.InitialBudget = item.InitialBudget;

            budget.TotalLeft = item.InitialBudget;

            using (var context = new BudgetWatcherContext())
            {
                context.Budgets.Attach(budget);
                context.Entry(budget).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
