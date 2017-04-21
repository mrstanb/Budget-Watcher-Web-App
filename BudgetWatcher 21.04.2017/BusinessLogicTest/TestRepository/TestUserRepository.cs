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
        User item = new User();
        IUserRepository userRepo = new UserRepository();

        [TestMethod]
        public void Add_Test()
        {
            item.Email = "stanimir@gmail.com";
            item.Password = "123456";
            item.FirstName = "Stanimir";
            item.LastName = "Bozhilov";

            userRepo.Add(item);
        }

        [TestMethod]
        public void GetAll_Test()
        {
            ICollection<User> users = new HashSet<User>();

            users = userRepo.GetAll();

            Assert.IsNotNull(users);
            Assert.AreEqual(users.Count, userRepo.GetAll().Count);
        }

        [TestMethod]
        public void GetById_Test()
        {
            item.Id = 14;
            item.Email = "stanimir@gmail.com";
            item.Password = "123456";
            item.FirstName = "Stanimir";
            item.LastName = "Bozhilov";

            item = userRepo.GetById(item.Id);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Delete_Test()
        {
            item.Id = 11;
            item.Email = "stanimir@gmail.com";
            item.Password = "123456";
            item.FirstName = "Stanimir";
            item.LastName = "Bozhilov";

            userRepo.Delete(item);
        }

        [TestMethod]
        public void GetUserByEmailAndPassword_Test()
        {
            item.Id = 1;
            item.Email = "stanimir@gmail.com";
            item.Password = "123456";
            item.FirstName = "Stanimir";
            item.LastName = "Bozhilov";

            userRepo.GetUserByEmailAndPassword(item.Email, item.Password);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Update_Test()
        {
            item.Id = 14;
            item.Email = "stanimir@gmail.com";
            item.Password = "123456";
            item.FirstName = "Stanimir";
            item.LastName = "Bozhilov";

            item.Password = "123456789";

            userRepo.Update(item);
        }
    }
}