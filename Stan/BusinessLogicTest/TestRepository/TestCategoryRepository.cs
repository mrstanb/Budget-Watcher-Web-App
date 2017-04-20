using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Entities;
using BusinessLogic.Repository;
using BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicTest.TestRepository
{
    [TestClass]
    public class TestCategoryRepository
    {
        Category item = new Category();
        ICategoryRepository categoryRepo = new CategoryRepository();

        [TestMethod]
        public void Add_Test()
        {
            item.Name = "Pet";
            item.IsActive = true;
            item.IsChosen = true;

            categoryRepo.Add(item);
        }

        [TestMethod]
        public void GetAll_Test()
        {
            ICollection<Category> categories = new HashSet<Category>();

            categories = categoryRepo.GetAll();

            Assert.IsNotNull(categories);
            Assert.AreEqual(categories.Count, categoryRepo.GetAll().Count);
        }

        [TestMethod]
        public void GetById_Test()
        {
            item.Id = 1;
            item.Name = "Pet";
            item.IsActive = true;
            item.IsChosen = true;

            item = categoryRepo.GetById(item.Id);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Update_Test()
        {
            item.Id = 1;
            item.Name = "Pet";
            item.IsActive = true;
            item.IsChosen = true;

            item.Name = "Cat";
            item.IsChosen = false;

            categoryRepo.Update(item);
        }

        [TestMethod]
        public void Delete_Test()
        {
            item.Id = 1;
            item.Name = "Pet";
            item.IsActive = true;
            item.IsChosen = true;

            categoryRepo.Delete(item);
        }
    }
}
