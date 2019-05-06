using BLL.Interface.Interfaces;
using DAL.Interface;
using DAL.Interface.DTO;
using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    static class AccountMapper
    {
        public static AccountDTO ToAccountDTO(IAccount account)
        {
            DAL.Interface.AccountType temp;
            Enum.TryParse(account.Type.ToString(), true, out temp);
            return new AccountDTO { AccountNumber = account.AccountNumber, Balance = account.Balance, Bonuses = account.Balance, Owner = account.Owner, Type = temp};
        }
        public static IAccount ToAccount (AccountDTO account)
        {
            BLL.Interface.Entities.AccountType temp;
            Enum.TryParse(account.Type.ToString(), true, out temp);
            return new Account(account.AccountNumber, account.Owner, temp) { Balance = account.Balance, Bonuses = account.Bonuses };
        }
    }
}
