using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private List<IAccount> _accounts;

        public void CloseAccount(int accountNumber)
        {
            int temp = FindAccount(accountNumber);
            if (temp != -1)
            {
                _accounts.RemoveAt(temp);
            }
            else
            {
                throw new Exception("Account dont exist");
            }
        }

        public void DepositAccount(int accountNumber, int summ)
        {
            int temp = FindAccount(accountNumber);
            if (temp != -1)
            {
                _accounts[temp].Balance += summ;
            }
            else
            {
                throw new Exception("Account dont exist");
            }
        }

        public IEnumerable<IAccount> GetAllAccounts()
        {
            IAccount[] temp =  new IAccount[_accounts.Count];
            _accounts.CopyTo(temp);
            return temp;
        }

        public void OpenAccount(string owner, AccountType type, IAccountNumberCreateService creator)
        {
            _accounts.Add(new Account(creator.GenerateNewAccountNumber() ,owner,type));
        }

        public void WithdrawAccount(int accountNumber, int summ)
        {
            int temp = FindAccount(accountNumber);
            if(temp!=-1)
            {
                _accounts[temp].Balance -= summ;
            }
            else
            {
                throw new Exception("Account dont exist");
            }
        }

        private int FindAccount(int number)
        {
            for(int i=0;i<=_accounts.Capacity-1;i++)
            {
                if(_accounts[i].AccountNumber==number)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
