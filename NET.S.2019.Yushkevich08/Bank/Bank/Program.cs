using Bank.Data.Models;
using Bank.Data.Presenters;
using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account("1234124124", "K", "Y", "Base");
            AccountService service = new AccountService();
            //service.AddAccount(a1);
            service.AddMoney("1234124124", 100000);
            foreach (Account a in service.AccountList)
            {
                Console.WriteLine(a);
            }
            service.WithdrawMoney("1234124124", 1200);
            foreach(Account a in service.AccountList)
            {
                Console.WriteLine(a);
            }
            service.RemoveAccount(a1);
            foreach (Account a in service.AccountList)
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();
        }
    }
}
