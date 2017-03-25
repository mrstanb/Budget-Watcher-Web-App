using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace BusinessLogic.DBContextDomain
{
    public class BudgetWatcherContext : DbContext
    {
        static BudgetWatcherContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<BudgetWatcherContext>());
        }

        public BudgetWatcherContext()
            :base("BudgetWatcher")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<SpendingCategory> SpendingCategories { get; set; }
    }
}
