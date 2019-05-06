using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private List<IAccount> _accounts;
        private IBonusesCalculator _calculator;
        private IRepository _repository;

        public AccountService(IBonusesCalculator calculator,IRepository rep)
        {
            _accounts = new List<IAccount>();
            _calculator = calculator;
            _repository = rep;
        }

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
                _calculator.UpdateBonuses(_accounts[temp], summ);
            }
            else
            {
                throw new Exception("Account dont exist");
            }
        }

        public IEnumerable<IAccount> GetAllAccounts()
        {
            if (_accounts.Capacity == 0)
            {
                return new IAccount[0];
            }
            else
            {
                IAccount[] temp = new IAccount[_accounts.Count];
                _accounts.CopyTo(temp);
                return temp;
            }
           
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
                _calculator.UpdateBonuses(_accounts[temp],summ);
            }
            else
            {
                throw new Exception("Account dont exist");
            }
        }
        
        public void SaveToDB()
        {
            _repository.SaveToFile(_accounts.Select(x=> Mappers.AccountMapper.ToAccountDTO(x)));
        }

        public void LoadFormDB()
        {
            _accounts = _repository.LoadFromFile().Select(x => Mappers.AccountMapper.ToAccount(x)).ToList();
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
