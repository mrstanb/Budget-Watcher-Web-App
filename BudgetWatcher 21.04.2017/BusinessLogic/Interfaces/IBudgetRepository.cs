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
        decimal GetBalance(Budget item);
        void ChangeBalance(Budget item);
    }
}