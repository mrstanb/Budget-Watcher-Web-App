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
    public class SpendingCategoryRepository : ISpendingCategoryRepository
    {
        SpendingCategory spendingCategory = new SpendingCategory();

        public void Add(SpendingCategory item)
        {
            using (var context = new BudgetWatcherContext())
            {
                context.SpendingCategories.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(SpendingCategory item)
        {
            throw new NotImplementedException();
        }

        public ICollection<SpendingCategory> GetAll()
        {
            ICollection<SpendingCategory> spendingCategories = new HashSet<SpendingCategory>();
            using (var context = new BudgetWatcherContext())
            {
                spendingCategories = context.SpendingCategories.ToList();
            }

            return spendingCategories;
        }

        public SpendingCategory GetById(int id)
        {
            using (var context = new BudgetWatcherContext())
            {
                spendingCategory = context.SpendingCategories.FirstOrDefault(x => x.Id == id);
            }

            return spendingCategory;
        }

        public void Update(SpendingCategory item)
        {
            spendingCategory = GetById(item.Id);

            if (spendingCategory == null)
            {
                throw new ArgumentNullException("Spending Category not found");
            }

            spendingCategory.CategoryName = item.CategoryName;
            spendingCategory.Description = item.Description;
            spendingCategory.MoneySpent = item.MoneySpent;
            spendingCategory.IsChosen = item.IsChosen;

            using (var context = new BudgetWatcherContext())
            {
                context.SpendingCategories.Attach(spendingCategory);
                context.Entry(spendingCategory).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
