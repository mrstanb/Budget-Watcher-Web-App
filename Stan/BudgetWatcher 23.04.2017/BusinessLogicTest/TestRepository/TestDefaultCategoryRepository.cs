using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Entities;
using BusinessLogic.Repository;
using BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicTest.TestRepository
{
    [TestClass]
    public class TestDefaultCategoryRepository
    {
        DefaultCategory item = new DefaultCategory();
        Category categoryItem = new Category();
        IDefaultCategoryRepository defaultCategoryRepo = new DefaultCategoryRepository();

        [TestMethod]
        public void GetAll_Test()
        {
            ICollection<DefaultCategory> defaultCategories = new HashSet<DefaultCategory>();

            defaultCategories = defaultCategoryRepo.GetAll();

            Assert.IsNotNull(defaultCategories);
            Assert.AreEqual(defaultCategories.Count, defaultCategoryRepo.GetAll().Count);
        }

        [TestMethod]
        public void GetById_Test()
        {
            item.Id = 1;
            item.Name = "Car";

            item = defaultCategoryRepo.GetById(item.Id);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void GetByName_Test()
        {
            item.Id = 1;
            item.Name = "Car";

            categoryItem.Id = 1;
            categoryItem.Name = "Car";
            categoryItem.IsActive = true;
            categoryItem.IsChosen = true;

            defaultCategoryRepo.GetByName(categoryItem);
            Assert.IsNotNull(categoryItem);
        }
    }
}
