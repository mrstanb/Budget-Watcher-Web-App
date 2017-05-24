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
    public class DefaultCategoryRepository : IDefaultCategoryRepository
    {
        private DefaultCategory defaultCategory = new DefaultCategory();

        public void Add(DefaultCategory item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DefaultCategory item)
        {
            throw new NotImplementedException();
        }

        public ICollection<DefaultCategory> GetAll()
        {
            ICollection<DefaultCategory> defaultCategories = new HashSet<DefaultCategory>();
            using (var context = new BudgetWatcherContext())
            {
                defaultCategories = context.DefaultCategories.ToList();
            }

            return defaultCategories;

        }

        public DefaultCategory GetById(int id)
        {
            using (var context = new BudgetWatcherContext())
            {
                defaultCategory = context.DefaultCategories.FirstOrDefault(x => x.Id == id);
            }

            return defaultCategory;
        }

        public DefaultCategory GetByName(Category item)
        {
            using (var context = new BudgetWatcherContext())
            {
                defaultCategory = context.DefaultCategories.FirstOrDefault(x => x.Name == item.Name);
            }

            return defaultCategory;

        }

        public void Update(DefaultCategory item)
        {
            throw new NotImplementedException();
        }
    }
}