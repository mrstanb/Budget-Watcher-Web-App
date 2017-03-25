using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities
{
    public class Budget
    {
        public int Id { get; set; }

        // Budget Info
        public decimal InitialBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal TotalLeft { get; set; }
    }
}