using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Entities;
using BusinessLogic.Repository;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTest.TestRepository
{
    [TestClass]
    public class TestSpendingRepository
    {
        Spending item = new Spending();
        ISpendingRepository spendingRepo = new SpendingRepository();

        [TestMethod]
        public void Add_Test()
        {
            item.Description = "bla bla";
            item.SpendingDate = DateTime.Now;
            item.MoneySpent = 5;

            spendingRepo.Add(item);
        }

        [TestMethod]
        public void GetAll_Test()
        {
            ICollection<Spending> spendings = new HashSet<Spending>();
            spendings = spendingRepo.GetAll();

            Assert.IsNotNull(spendings);
            Assert.AreEqual(spendings.Count, spendingRepo.GetAll().Count);
        }

        [TestMethod]
        public void GetById_Test()
        {
            item.Id = 1;
            item.Description = "bla bla";
            item.SpendingDate = DateTime.Now;
            item.MoneySpent = 5;

            spendingRepo.GetById(item.Id);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Update_Test()
        {
            item.Id = 1;
            item.Description = "bla bla";
            item.SpendingDate = DateTime.Now;
            item.MoneySpent = 5;

            item.MoneySpent = 7;

            spendingRepo.Update(item);
        }
    }
}
