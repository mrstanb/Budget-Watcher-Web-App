using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities
{
    public class User
    {
        public User()
        {
            Budgets = new HashSet<Budget>();
        }

        // User Information
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
       

        // Budget Info
        public virtual ICollection<Budget> Budgets { get; set; }
    }
}
