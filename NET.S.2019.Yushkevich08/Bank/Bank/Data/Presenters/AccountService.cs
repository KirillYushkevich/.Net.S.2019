using System;
using System.Collections.Generic;
using Bank.Data.Models;

namespace Bank.Data.Presenters
{
    public class AccountService
    {
        public List<Account> AccountList = new List<Account>();

        private const string StoragePath = "AccountStorage.bin";

        public AccountService()
        {
            AccountList = StorageService.LoadFromFile(StoragePath);
        }

        ~AccountService()
        {
            StorageService.SaveToFile(StoragePath, AccountList);
        }

        /// <summary>Add acount in List</summary>
        /// <param name="newAccount">Second Account</param>
        public void AddAccount(Account newAccount)
        {
            if (AccountList.Contains(newAccount))
            {
                throw new Exception("This Account already in storage");
            }

            AccountList.Add(newAccount);
        }

        /// <summary>Remove acount from List</summary>
        /// <param name="newAccount">Second Account</param>
        public void RemoveAccount(Account newAccount)
        {
            if (!AccountList.Contains(newAccount))
            {
                throw new Exception("There is no such Account in storage");
            }

            AccountList.Remove(newAccount);
        }

        /// <summary>Add monney to acount </summary>
        /// <param name="id">account id</param>
        /// <param name="sum">summ to add</param>
        public void AddMoney(string id, int sum)
        {
            foreach (Account a in AccountList)
            {
                if (a.ID == id)
                {
                    a.Balance += sum;
                    return;
                }
            }
        }

        /// <summary>Withdraw monney from acount </summary>
        /// <param name="id">account id</param>
        /// <param name="sum">summ to withdraw</param>
        public void WithdrawMoney(string id, int sum)
        {
            foreach (Account a in AccountList)
            {
                if (a.ID == id)
                {
                    a.Balance -= sum;
                    return;
                }
            }
        }
    }
}
