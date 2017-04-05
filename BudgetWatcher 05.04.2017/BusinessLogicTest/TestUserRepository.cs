using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Entities;
using BusinessLogic.Repository;
using BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace TestBusinessLogic
{
    [TestClass]
    public class TestUserRepository
    {
        [TestMethod]
        public void Add_Test()
        {
            User item = new User();
            item.Email = "stanimir@gmail.com";
            item.Password = "123456";
            item.FirstName = "Stanimir";
            item.LastName = "Bozhilov";

            IUserRepository userRepo = new UserRepository();
            userRepo.Add(item);
        }

        [TestMethod]
        public void GetAll_Test()
        {
            ICollection<User> users = new HashSet<User>();

            IUserRepository userRepo = new UserRepository();
            users = userRepo.GetAll();

            Assert.IsNotNull(users);
            Assert.AreEqual(users.Count, userRepo.GetAll().Count);
        }
    }
}
