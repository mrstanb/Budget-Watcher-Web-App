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
    public class SpendingCategoryRepository : ICategoryRepository
    {
        private Category category = new Category();
        private DefaultCategoryRepository defaultCategoryRepo = new DefaultCategoryRepository();
        private DefaultCategory defaultCategory = new DefaultCategory();

        public void Add(Category item)
        {
            defaultCategory = defaultCategoryRepo.GetByName(item);

            if (defaultCategory != null)
            {
                item.DefaultCategories.Add(defaultCategory);
            }
            else
            {
                item.DefaultCategories.Add(null);
            }

            category = item;

            category.Name = item.Name;
            category.IsActive = true;
            category.IsChosen = item.IsChosen; 

            using (var context = new BudgetWatcherContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void Delete(Category item)
        {
            category = GetById(item.Id);
            category.IsActive = false;
            category.IsChosen = false;
            using (var context = new BudgetWatcherContext())
            {
                context.Categories.Attach(category);
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        public ICollection<Category> GetAll()
        {
            ICollection<Category> categories = new HashSet<Category>();
            using (var context = new BudgetWatcherContext())
            {
                categories = context.Categories.ToList();
            }

            return categories;
        }

        public Category GetById(int id)
        {
            using (var context = new BudgetWatcherContext())
            {
                category = context.Categories.FirstOrDefault(x => x.Id == id);
            }

            return category;
        }

        public void Update(Category item)
        {
            category = GetById(item.Id);

            if (category == null)
            {
                throw new ArgumentNullException("Spending Category not found");
            }

            defaultCategory = defaultCategoryRepo.GetByName(category);
            if (defaultCategory != null)
            {
                throw new Exception("You cannot change Default Category");
            }

            category.Name = item.Name;
            category.IsActive = true;

            using (var context = new BudgetWatcherContext())
            {
                context.Categories.Attach(category);
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}