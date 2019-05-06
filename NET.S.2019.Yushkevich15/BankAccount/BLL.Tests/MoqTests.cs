using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using NUnit.Framework;
using DAL.Interface.Interfaces;
using BLL.ServiceImplementation;

namespace BLL.Tests
{
    class MoqTests
    {
        private IAccountService accountService;
        private AccountNumberCreator creator;

        [SetUp]
        public void SetUp()
        {
            accountService = new Mock<AccountService>(new Mock<IBonusesCalculator>().Object, new Mock<IRepository>().Object).Object;
            creator = new Mock<AccountNumberCreator>().Object;
        }

        [Test]
        public void MoqTestOpen()
        {
            accountService.OpenAccount("owner1", AccountType.Base, creator);
            var temp = accountService.GetAllAccounts();
            Assert.AreEqual(1, temp.Count());
        }

        [Test]
        public void MoqTestClose()
        {
            accountService.OpenAccount("owner1", AccountType.Base, creator);
            accountService.CloseAccount(creator.Last);
            var temp = accountService.GetAllAccounts();
            Assert.AreEqual(0, temp.Count());
        }

        [Test]
        public void MoqTestDeposite()
        {
            accountService.OpenAccount("owner1", AccountType.Base, creator);
            accountService.DepositAccount(creator.Last, 200);
            var temp = accountService.GetAllAccounts().Select(x => x.Balance).ToArray();
            Assert.AreEqual(200, temp[0]);
        }

        [Test]
        public void MoqTestWithdraw()
        {
            accountService.OpenAccount("owner1", AccountType.Base, creator);
            accountService.DepositAccount(creator.Last, 200);
            accountService.WithdrawAccount(creator.Last, 100);
            var temp = accountService.GetAllAccounts().Select(x => x.Balance).ToArray();
            Assert.AreEqual(100, temp[0]);
        }


    }
}
