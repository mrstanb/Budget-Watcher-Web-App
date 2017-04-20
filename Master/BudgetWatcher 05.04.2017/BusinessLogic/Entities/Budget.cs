using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities
{
    public class Budget
    {
        public Budget()
        {
            Spendings = new HashSet<Spending>();
        }

        public int Id { get; set; }

        // Budget Info
        public decimal InitialBalance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Spending> Spendings { get; set; }
    }
}