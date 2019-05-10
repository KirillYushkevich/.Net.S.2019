using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class Account : IAccount
    {
        private int _bonuses;
        private int _balance;

        public Account(int id, string owner, AccountType type)
        {
            AccountNumber = id;
            Owner = owner;
            Balance = 0;
            Bonuses = 0;
            Type = type;
        }

        public int Bonuses
        {
            get => _bonuses;
            set
            {
                if (value < 0)
                {
                    _bonuses = 0;
                }

                _bonuses = value;
            }
        }

        public int Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                {
                    throw new Exception();
                }

                _balance = value;
            }
        }

        public AccountType Type { get; set; }

        public int AccountNumber { get; set; }

        public string Owner { get; set; }

        public override string ToString()
        {
            return "ID: " + AccountNumber + " Status: " + Balance;
        }
    }
}
