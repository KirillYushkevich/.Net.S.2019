using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void OpenAccount(string owner,AccountType type,IAccountNumberCreateService creator);
        IEnumerable<IAccount> GetAllAccounts();
        void DepositAccount(int accountNumber,int summ);
        void WithdrawAccount(int accountNumber, int summ);
        void CloseAccount(int accountNumber);
    }
}
