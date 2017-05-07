using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Category
    {
        public Category()
        {
            DefaultCategories = new HashSet<DefaultCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsChosen { get; set; }

        public virtual ICollection<DefaultCategory> DefaultCategories { get; set; }
    }
}