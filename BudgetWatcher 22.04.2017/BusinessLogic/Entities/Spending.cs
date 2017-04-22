using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities
{
    public class Spending
    {
        public Spending()
        {
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public DateTime SpendingDate { get; set; }
        public decimal MoneySpent { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}