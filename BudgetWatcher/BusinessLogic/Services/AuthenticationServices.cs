using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public static class AuthenticationServices
    {
        public static User LoggedUser { get; set; }

        public static void AuthenticationUser(string Email, string Password)
        {
            IUserRepository userRepo = new UserRepository();
            LoggedUser = userRepo.GetUserByEmailAndPassword(Email, Password);
        }
    }
}
