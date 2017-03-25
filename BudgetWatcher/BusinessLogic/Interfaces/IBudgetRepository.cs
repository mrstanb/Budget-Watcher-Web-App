using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IBudgetRepository : IGenericRepository<Budget>
    {
        void AddTotalPriceChanges(Budget budgetItem);
        decimal GetTotal(Budget item);
    }
}
