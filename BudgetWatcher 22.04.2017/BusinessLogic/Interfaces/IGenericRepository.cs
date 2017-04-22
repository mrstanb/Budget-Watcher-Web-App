using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IGenericRepository<T>
    {
        T GetById(int id);
        ICollection<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}