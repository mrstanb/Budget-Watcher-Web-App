using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public static class BudgetManager
    {
        //private static ICollection<Spending> allSpendings = new HashSet<Spending>();
        private static decimal sum;

        public static void CalcSpendingsSum(ICollection<SpendingCategory> spendingCats)
        {
            if(spendingCats == null)
            {
                throw new ArgumentNullException("No Spent Money Found.");
            }

            foreach (var spendingCat in spendingCats)
            {
                sum += spendingCat.MoneySpent;
            }
        }
    }
}
