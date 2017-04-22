using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByEmailAndPassword(string Email, string Password);
    }
}