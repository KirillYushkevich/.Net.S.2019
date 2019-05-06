using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class Account : IAccount
    {
        public int AccountNumber { get; set; }
        private int _bonuses;
        public int Bonuses
        {
            get => _bonuses;
            set
            {
                if(value<0)
                {
                    _bonuses = 0;
                }
                _bonuses = value;
            }
        }
        public AccountType Type { get; set; }
        public string Owner { get ; set ; }
        private int _balance;
        public int Balance
        {
            get => _balance;
            set
            {
                if (value<0)
                {
                    throw new Exception();
                }
                _balance = value;
            }
        }

        public Account(int id,string owner,AccountType type)
        {
            AccountNumber = id;
            Owner = owner;
            Balance = 0;
            Bonuses = 0;
            Type = type;
        }
        public override string ToString()
        {
            return "ID: "+AccountNumber+" Status: "+Balance;
        }
    }
}
