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
    public class SpendingRepository : ISpendingRepository
    {
        private Spending spending = new Spending();

        public void Add(Spending item)
        {
            spending.Description = item.Description;
            spending.SpendingDate = DateTime.Now;
            spending.MoneySpent = item.MoneySpent;

            using (var context = new BudgetWatcherContext())
            {
                context.Spendings.Add(spending);
                context.SaveChanges();
            }
        }

        // Optional
        public void Delete(Spending item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Spending> GetAll()
        {
            ICollection<Spending> spendings = new HashSet<Spending>();
            using (var context = new BudgetWatcherContext())
            {
                spendings = context.Spendings.ToList();
            }

            return spendings;
        }

        public Spending GetById(int? id)
        {
            using (var context = new BudgetWatcherContext())
            {
                spending = context.Spendings.FirstOrDefault(x => x.Id == id);
            }

            if (spending == null)
            {
                throw new ArgumentNullException("Oops, spending does not exist :)");
            }

            return spending;
        }

        public void Update(Spending item)
        {
            spending = GetById(item.Id);

            if (spending == null)
            {
                throw new ArgumentNullException("Ooops, something wrong occured :)");
            }

            spending.Description = item.Description;
            spending.SpendingDate = DateTime.Now;
            spending.MoneySpent = item.MoneySpent;

            using (var context = new BudgetWatcherContext())
            {
                context.Spendings.Attach(spending);
                context.Entry(spending).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}