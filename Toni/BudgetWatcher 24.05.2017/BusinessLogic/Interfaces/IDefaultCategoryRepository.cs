using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IDefaultCategoryRepository : IGenericRepository<DefaultCategory>
    {
        DefaultCategory GetByName(Category item);
    }
}