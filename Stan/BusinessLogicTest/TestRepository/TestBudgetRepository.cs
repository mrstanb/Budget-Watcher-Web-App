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
    public class TestBudgetRepository
    {
        Budget item = new Budget();
        IBudgetRepository budgetRepo = new BudgetRepository();

        [TestMethod]
        public void Add_Test()
        {
            item.InitialBalance = 100;
            item.StartDate = DateTime.Now;
            item.EndDate = DateTime.Now;
            item.Balance = item.InitialBalance;

            budgetRepo.Add(item);
        }

        [TestMethod]
        public void GetById_Test()
        {
            item.Id = 6;
            item.InitialBalance = 100;
            item.StartDate = DateTime.Now;
            item.EndDate = DateTime.Now;
            item.Balance = item.InitialBalance;

            budgetRepo.GetById(item.Id);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void GetAll_Test()
        {
            ICollection<Budget> budgets = new HashSet<Budget>();
            budgets = budgetRepo.GetAll();

            Assert.IsNotNull(budgets);
            Assert.AreEqual(budgets.Count, budgetRepo.GetAll().Count);
        }

        [TestMethod]
        public void Update_Test()
        {
            item.Id = 5;
            item.InitialBalance = 100;
            item.StartDate = DateTime.Now;
            item.EndDate = DateTime.Now;
            item.Balance = item.InitialBalance;

            item.Balance = item.InitialBalance - 20;

            budgetRepo.Update(item);
        }

        [TestMethod]
        public void ChangeBalance_Test()
        {
            item.Id = 5;
            item.InitialBalance = 100;
            item.StartDate = DateTime.Now;
            item.EndDate = DateTime.Now;
            item.Balance = item.InitialBalance;

            item.Balance = item.InitialBalance - 30;

            budgetRepo.ChangeBalance(item);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void GetBalance_Test()
        {
            item.Id = 5;
            item.InitialBalance = 100;
            item.StartDate = DateTime.Now;
            item.EndDate = DateTime.Now;
            item.Balance = item.InitialBalance;

            budgetRepo.GetBalance(item);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Delete_Test()
        {
            item.Id = 5;
            item.InitialBalance = 100;
            item.StartDate = DateTime.Now;
            item.EndDate = DateTime.Now;
            item.Balance = item.InitialBalance;

            budgetRepo.Delete(item);
        }
    }
}
