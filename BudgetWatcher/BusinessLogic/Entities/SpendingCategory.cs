using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities
{
    public class SpendingCategory
    {
        // Food, Accommodation, etc.

        public int Id { get; set; }
        
        // Info about the Category
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public decimal MoneySpent { get; set; }

        // Flags
        public bool IsChosen { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCustom { get; set; }
    }
}