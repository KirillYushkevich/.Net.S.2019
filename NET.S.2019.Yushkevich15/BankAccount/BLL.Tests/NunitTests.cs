using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ninject;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using BLL.ServiceImplementation;
using DAL.Repositories;

namespace BLL.Tests
{
    [TestFixture]
    class NunitTests
    {
        private IAccountService accountService;
        private AccountNumberCreator creator;
        
        [SetUp]
        public void SetUp()
        {
            accountService = new AccountService(new BonusesCalculator(),new AccountBinaryRepository("test.bin"));
            creator = new AccountNumberCreator();
        }

        [Test]
        public void TestOpen()
        {
            accountService.OpenAccount("owner1", AccountType.Base, creator);
            var temp =  accountService.GetAllAccounts();        
            Assert.AreEqual(1,temp.Count());
        }

        [Test]
        public void TestClose()
        {
            accountService.OpenAccount("owner1", AccountType.Base, creator);
            accountService.CloseAccount(creator.Last);
            var temp = accountService.GetAllAccounts();
            Assert.AreEqual(0, temp.Count());
        }

        [Test]
        public void TestDeposite()
        {
            accountService.OpenAccount("owner1", AccountType.Base, creator);
            accountService.DepositAccount(creator.Last, 200);
            var temp = accountService.GetAllAccounts().Select(x=> x.Balance).ToArray();
            Assert.AreEqual(200, temp[0]);
        }

        [Test]
        public void TestWithdraw()
        {
            accountService.OpenAccount("owner1", AccountType.Base, creator);
            accountService.DepositAccount(creator.Last, 200);
            accountService.WithdrawAccount(creator.Last, 100);
            var temp = accountService.GetAllAccounts().Select(x => x.Balance).ToArray();
            Assert.AreEqual(100, temp[0]);
        }
    }
}
